using Microsoft.AspNetCore.SignalR;
using EasySpeak.Core.Common.DTO;
using EasySpeak.RabbitMQ.Interfaces;

namespace EasySpeak.Notifier.WebAPI.Hubs
{

    public class NotificationsHub : Hub
    {
        public string QueueName { get; set; }

        public NotificationsHub()
        {
        }
        public override async Task OnConnectedAsync()
        {
            
            var userEmail = Context.User.Identities.First();
            QueueName = "notifications_for_test@test.ua";
            await Groups.AddToGroupAsync(Context.ConnectionId, QueueName);
        }
    }
}
