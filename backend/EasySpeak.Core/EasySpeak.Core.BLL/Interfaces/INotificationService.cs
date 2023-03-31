using EasySpeak.Core.Common.DTO.Notification;
using EasySpeak.Core.DAL.Entities;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface INotificationService
    {
        Task<ICollection<NotificationDto>> GetNotificationsAsync();
        Task<NotificationDto> CreateNotificationAsync(Notification notification);
        Task<long> ReadNotificationAsync(long id);
    }
}
