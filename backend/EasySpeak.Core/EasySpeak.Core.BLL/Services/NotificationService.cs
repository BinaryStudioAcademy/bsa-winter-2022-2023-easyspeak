using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Notification;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using EasySpeak.RabbitMQ.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services
{
    public class NotificationService : BaseService, INotificationService
    {
        private readonly EasySpeakCoreContext _context;
        private readonly IFirebaseAuthService _firebaseAuthService;
        private readonly IMessageProducer _messageProducer;
        public NotificationService(
            IFirebaseAuthService firebaseAuthService, 
            EasySpeakCoreContext context, 
            IMessageProducer messageProducer,
            IMapper mapper
            )
            :base(context, mapper)
        {
            _firebaseAuthService = firebaseAuthService;
            _context = context;
            _messageProducer = messageProducer;
        }

        public async Task<ICollection<NotificationDto>> GetNotificationsAsync() =>
            await _context.Notifications
                .Where(notify => notify.UserId == _firebaseAuthService.UserId && !notify.IsRead)
                .Select(notify =>
                        new NotificationDto
                        {
                            Id = notify.Id,
                            Text = notify.Text,
                            Type = notify.Type
                        })
                .ToListAsync();

        public async Task<NotificationDto> CreateNotificationAsync(Notification notification)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == _firebaseAuthService.UserId);
            
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();

            var notificationDto = _mapper.Map<NotificationDto>(notification);

            SendNotificationToRabbit(user, notificationDto);

            return _mapper.Map<NotificationDto>(new Tuple<long, NotificationDto>(notification.UserId, notificationDto));
        }

        public async Task<long> ReadNotificationAsync(long id)
        {
            var notification = await _context.Notifications.FirstOrDefaultAsync(n => n.Id == id);

            if (notification is not null)
            {
                notification.IsRead = true;

                _context.Notifications.Update(notification);
                await _context.SaveChangesAsync();
            }
            return id;
        }

        private void SendNotificationToRabbit(User user, NotificationDto notification)
        {
            _messageProducer.Init("notifier", "");
            _messageProducer.SendMessage<NotificationDto>(notification);
        }

        private async Task GenerateNotification(NotificationType type, long id)
        {
            switch (type)
            {
                case NotificationType.friendshipRequest:
                    await NotifyOnFriendshipRequest(id);
                    break;
                case NotificationType.friendshipAcception:
                    await NotifyOnFriendshipAcception(id);
                    break;
                case NotificationType.classJoin:
                    await GenerateGroupJoinNotification(id);
                    break;
            }
        }

        private async Task NotifyOnFriendshipRequest(long id)
        {
            var receiverId = await _context.Users.Where(u => u.Id == id)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();

            var relatedUser = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == _firebaseAuthService.UserId);

            var notification = new Notification()
            {
                IsRead = false,
                UserId = receiverId,
                RelatedTo = relatedUser!.Id,
                CreatedAt = DateTime.Now,
                Type = NotificationType.friendshipRequest,
                Text = $"{relatedUser.FirstName} {relatedUser.LastName} wants to add you to friends"
            };

            await CreateNotificationAsync(notification);
        }

        private async Task NotifyOnFriendshipAcception(long id)
        {
            var relatedUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            var notification = new Notification()
            {
                IsRead = false,
                UserId = _firebaseAuthService.UserId,
                RelatedTo = relatedUser!.Id,
                CreatedAt = DateTime.Now,
                Type = NotificationType.friendshipAcception,
                Text = $"You are now friends with {relatedUser.FirstName} {relatedUser.LastName}"
            };

            await CreateNotificationAsync(notification);
        }

        private async Task GenerateGroupJoinNotification(long id)
        {
            var lesson = await _context.Lessons
                .Include(l => l.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            var notification = new Notification()
            {
                IsRead = false,
                UserId = _firebaseAuthService.UserId,
                RelatedTo = lesson.User.Id,
                CreatedAt = DateTime.Now,
                Type = NotificationType.classJoin,
                Text = $"Congratulations! You've joined the Croup Class: " +
                       $"{lesson.Name}, {lesson.CreatedAt:dd MMMM, HH:mm}"
            };
            
            await CreateNotificationAsync(notification);
        }
    }
}
