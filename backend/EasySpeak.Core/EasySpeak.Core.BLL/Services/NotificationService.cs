using AutoMapper;
using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Notification;
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

        public async Task<NotificationDto> CreateNotificationAsync(NewNotificationDto notificationDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == _firebaseAuthService.UserId);

            var notification = _mapper.Map<Notification>(notificationDto);
            notification.UserId = user!.Id;

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();

            this.SendNotificationToRabbit(user, notificationDto);

            return _mapper.Map<NotificationDto>(notification);
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

        public void SendNotificationToRabbit(User user, NewNotificationDto notification)
        {
            _messageProducer.Init("notifier", "");
            _messageProducer.SendMessage<NewNotificationDto>(notification);
        }
    }
}
