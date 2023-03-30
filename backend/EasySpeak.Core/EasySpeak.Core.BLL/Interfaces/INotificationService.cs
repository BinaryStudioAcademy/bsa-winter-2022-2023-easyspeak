using EasySpeak.Core.Common.DTO.Notification;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface INotificationService
    {
        Task<ICollection<NotificationDto>> GetNotificationsAsync();
        Task<NotificationDto> CreateNotificationAsync(NewNotificationDto notificationDto);
        Task<long> ReadNotificationAsync(long id);
    }
}
