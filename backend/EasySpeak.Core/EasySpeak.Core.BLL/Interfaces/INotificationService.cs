using EasySpeak.Core.Common.DTO.Notification;
using EasySpeak.Core.Common.Enums;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface INotificationService
    {
        Task<ICollection<NotificationDto>> GetNotificationsAsync();
        Task<NotificationDto> AddNotificationAsync(NotificationType type, long id);
        Task<long> ReadNotificationAsync(long id);
        Task ReadAllNotificationsAsync();
    }
}
