using Microsoft.AspNetCore.SignalR;
using EasySpeak.Core.Common.DTO.Notification;
using Newtonsoft.Json;

namespace EasySpeak.Notifier.WebAPI.Hubs
{

    public class NotificationHub : Hub
    {
        private static readonly Dictionary<string, string> ConnectedUsers = new();

        public void Connect(string email)
        {
            if (!ConnectedUsers.ContainsKey(email))
            {
                ConnectedUsers[email] = Context.ConnectionId;
            }
        }

        public void Disconnect(string email)
        {
            if (!ConnectedUsers.ContainsKey(email))
            {
                ConnectedUsers.Remove(email);
            }
        }

        public async Task SendNotification(string email, NotificationDto message)
        {
            string connectionId = ConnectedUsers[email];
            
            await Clients.Client(connectionId).SendAsync("Notify", JsonConvert.SerializeObject(message));
        }
    }
}
