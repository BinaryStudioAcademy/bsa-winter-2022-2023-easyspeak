using EasySpeak.Core.Common.DTO;

namespace EasySpeak.Core.BLL.Interfaces
{
    public interface INotificationsSenderService
    {
        void SendNotification(NotificationDto notification);
    }
}
