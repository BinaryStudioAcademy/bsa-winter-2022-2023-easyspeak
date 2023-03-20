using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO.Notification;
using EasySpeak.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace EasySpeak.Core.BLL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly EasySpeakCoreContext _context;
        private readonly IFirebaseAuthService _firebaseAuthService;
        public NotificationService(IFirebaseAuthService firebaseAuthService, EasySpeakCoreContext context)
        {
            _firebaseAuthService = firebaseAuthService;
            _context = context;
        }

        public async Task<ICollection<NotificationDto>> GetNotificationsAsync()
        {
            var notifications = await _context.Notifications
                .Where(notify => notify.UserId == _firebaseAuthService.UserId
                                && !notify.IsRead
                                )
                .Join(_context.Users,
                    notify => notify.SenderId,
                    user => user.Id,
                    (notify, user) =>
                        new NotificationDto
                        {
                            Id = notify.Id,
                            SenderName = user.FirstName + " " + user.LastName,
                            SenderImagePath = user.ImagePath,
                            Text = notify.Text,
                        }
                )
                .ToListAsync();

            return notifications;
        }
    }
}
