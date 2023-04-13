﻿using EasySpeak.Core.Common.DTO;
using Microsoft.AspNetCore.SignalR;

namespace EasySpeak.Core.WebAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task AddToGroup(int[] chatIds)
        {
            await Task.WhenAll(chatIds.Select(chatId => Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString())));
        }

        public async Task SendMessageAsync(NewMessageDto message)
        {
            await Clients.Group(message.ChatId.ToString()).SendAsync("message", message);
        }
    }
}