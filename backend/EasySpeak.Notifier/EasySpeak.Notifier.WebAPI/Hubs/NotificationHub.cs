﻿using Microsoft.AspNetCore.SignalR;
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
            ConnectedUsers.Remove(email);
        }

        public async Task SendNotification(string email, NotificationDto message)
        {
            var user = ConnectedUsers[email];
            await Clients.Client(user).SendAsync("Notify", JsonConvert.SerializeObject(message));
        }
    }
}
