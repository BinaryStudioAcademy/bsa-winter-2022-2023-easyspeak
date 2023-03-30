using Microsoft.AspNetCore.SignalR;
using EasySpeak.Core.Common.DTO.Notification;

namespace EasySpeak.Notifier.WebAPI.Hubs
{

    public class NotificationHub : Hub
    {
        public async Task SendAsync(NotificationDto notification)
        {
        }
    }
}
