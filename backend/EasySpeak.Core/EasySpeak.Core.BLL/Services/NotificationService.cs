using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Notification;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using EasySpeak.RabbitMQ.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EasySpeak.Core.BLL.Services
{
    public class NotificationService : BaseService, INotificationService
    {
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
            _messageProducer = messageProducer;
        }

        public async Task<NotificationDto> AddNotificationAsync(NotificationType type, long id)
        {
            var newNotification = await CreateNotificationAsync(type, id);

            var notificationDto = await SaveNotificationAsync(newNotification);

            SendNotificationToRabbit(newNotification.Email, notificationDto);

            return notificationDto;
        }
        
        public async Task<ICollection<NotificationDto>> GetNotificationsAsync()
        {
            var notifications = new List<NotificationDto>();
            
            notifications.AddRange(await GetNotificationsAsync(NotificationType.reminding));
            notifications.AddRange(await GetNotificationsAsync(NotificationType.classJoin));
            notifications.AddRange(await GetNotificationsAsync(NotificationType.friendshipRequest));
            notifications.AddRange(await GetNotificationsAsync(NotificationType.friendshipAcception));

            return notifications.OrderByDescending(n => n.CreatedAt).ToList();
        }

        public async Task<NotificationDto> SaveNotificationAsync(NewNotificationDto newNotification)
        {
            var notification = _mapper.Map<Notification>(newNotification);

            await _context.Notifications.AddAsync(notification);
            
            await _context.SaveChangesAsync();

            newNotification.Id = notification.Id;

            return _mapper.Map<NotificationDto>(newNotification);
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

        private void SendNotificationToRabbit(string email, NotificationDto notification)
        {
            _messageProducer.Init("notifier", "");
            _messageProducer.SendMessage(new Tuple<string, NotificationDto>(email, notification));
        }

        private async Task<NewNotificationDto> CreateNotificationAsync(NotificationType type, long id)
        {
            NewNotificationDto notification = type switch
            {
                NotificationType.friendshipRequest => await CreateFriendshipNotificationAsync(_firebaseAuthService.UserId, id, type),
                NotificationType.friendshipAcception => await CreateFriendshipNotificationAsync(id, _firebaseAuthService.UserId, type),
                NotificationType.classJoin => await CreateLessonNotificationAsync(id, _firebaseAuthService.UserId, type),
                NotificationType.reminding => await CreateLessonNotificationAsync(id, _firebaseAuthService.UserId, type),
                _ => null
            } ?? throw new InvalidOperationException("The notification type doesn't correspond to any of available types." +
                                                     " Ensure that type of notification is correct");

            return notification;
        }
        
        private async Task<List<NotificationDto>> GetNotificationsAsync(NotificationType type)
        { 
            List<NotificationDto> notifications = type switch
            {
                NotificationType.friendshipRequest => await GetFriendshipNotificationsAsync(type),
                NotificationType.friendshipAcception => await GetFriendshipNotificationsAsync(type),
                NotificationType.classJoin => await GetLessonNotificationsAsync(type),
                NotificationType.reminding => await GetLessonNotificationsAsync(type),
                _ => new List<NotificationDto>()
            };

            return notifications;
        }

        private async Task<NewNotificationDto> CreateFriendshipNotificationAsync(long senderId, long receiverId, NotificationType type)
        {
            var sender = await GetUserOrThrowErrorAsync(senderId);

            var receiver = await GetUserOrThrowErrorAsync(receiverId);

            var text = type switch
            {
                NotificationType.friendshipAcception =>
                    $"You are now friends with <strong>{sender.FirstName} {sender.LastName}</strong>",
                NotificationType.friendshipRequest =>
                    $"<strong>{sender.FirstName} {sender.LastName}</strong> wants to add you to friends",
                _ => string.Empty
            };

            var imagePath = await GetProfileImageUrl(sender.ImageId);

            return new NewNotificationDto()
            {
                IsRead = false,
                UserId = receiver.Id,
                Email = receiver.Email,
                RelatedTo = sender.Id,
                CreatedAt = DateTime.Now,
                Type = type,
                Text = text,
                ImageId = sender.ImageId
            };
        }

        private async Task<NewNotificationDto> CreateLessonNotificationAsync(long lessonId, long receiverId, NotificationType type)
        {
            var lesson = await GetLessonOrThrowErrorAsync(lessonId);

            var receiver = await GetUserOrThrowErrorAsync(receiverId);

            var text = type switch
            {
                NotificationType.classJoin => $"Congratulations! You've joined the Group Class: " +
                                              $"<strong>{lesson.Name}, {lesson.CreatedAt:dd MMMM, HH:mm}</strong>",
                NotificationType.reminding => $"The lesson is starting in <strong>30 minutes</strong>! Don't miss it.",
                _ => string.Empty
            };
            
            var imagePath = await GetProfileImageUrl(lesson.User!.ImageId);

            return new NewNotificationDto()
            {
                IsRead = false,
                UserId = receiver.Id,
                Email = receiver.Email,
                RelatedTo = lesson.User!.Id,
                CreatedAt = DateTime.Now,
                Type = type,
                Text = text,
                ImageId = lesson.User!.ImageId
            };
        }

        private async Task<List<NotificationDto>> GetFriendshipNotificationsAsync(NotificationType type)
        {
            return await _context.Notifications
                .Where(n => n.UserId == _firebaseAuthService.UserId && n.Type == type)
                .LeftJoin(_context.EasySpeakFiles,
                    n => n.RelatedTo,
                    u => u.UserId,
                    (n, u) => new {Notification = n, ImagePath = u.Url})
                .Select(x => new NotificationDto()
                {
                    Id = x.Notification.Id,
                    CreatedAt = x.Notification.CreatedAt,
                    IsRead = x.Notification.IsRead,
                    Text = x.Notification.Text,
                    Type = x.Notification.Type,
                    ImagePath = x.ImagePath
                })
                .ToListAsync();
        }

        private async Task<List<NotificationDto>> GetLessonNotificationsAsync(NotificationType type)
        {
            return await _context.Notifications
                .Where(n => n.UserId == _firebaseAuthService.UserId && n.Type == type)
                .LeftJoin(_context.EasySpeakFiles,
                    n => n.RelatedTo,
                    u => u.UserId,
                    (n, u) => new {Notification = n, ImagePath = u.Url})
                .Select(x => new NotificationDto()
                {
                    Id = x.Notification.Id,
                    CreatedAt = x.Notification.CreatedAt,
                    IsRead = x.Notification.IsRead,
                    Text = x.Notification.Text,
                    Type = x.Notification.Type,
                    ImagePath = x.ImagePath
                })
                .ToListAsync();
        }

        public async Task ReadAllNotificationsAsync()
        {
            var notifications = await _context.Notifications
                .Where(n => n.UserId == _firebaseAuthService.UserId && n.IsRead == false)
                .ToListAsync();

            foreach (var notification in notifications)
            {
                notification.IsRead = true;
            }

            await _context.SaveChangesAsync();
        }

        private async Task<User> GetUserOrThrowErrorAsync(long id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id)
                   ?? throw new ArgumentException($"User with id {id} not found");
        }

        private async Task<Lesson> GetLessonOrThrowErrorAsync(long id)
        {
            return await _context.Lessons
                       .Include(l => l.User)
                       .FirstOrDefaultAsync(l => l.Id == id)
                   ?? throw new ArgumentException($"Lesson with id {id} not found");
        }
        
        private async Task<string> GetProfileImageUrl(long? imageId)
        {
            var profileImage = await _context.EasySpeakFiles.FirstOrDefaultAsync(f => f.Id == imageId);
            return profileImage?.Url ?? ""; 
        }
        
    }
}
