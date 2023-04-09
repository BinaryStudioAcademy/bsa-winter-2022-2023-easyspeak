using EasySpeak.Core.BLL.Interfaces;
using EasySpeak.Core.Common.DTO;
using Microsoft.AspNetCore.SignalR;

namespace EasySpeak.Core.WebAPI.Hubs
{
    public class ChatHub : Hub
    {
        static readonly Dictionary<string, List<string>> ConnectedClients = new Dictionary<string, List<string>>();
        IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task AddToGroup(int[] chatIds)
        {
            await Task.WhenAll(chatIds.Select(chatId => Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString())));
        }

        public async Task GetPeopleAsync(long chatId, long userId)
        {
            var anotherUserId = await _chatService.GetAnotherUserId(chatId, userId);

            List<ChatPersonDto> peopleForThis = await _chatService.GetUnreadAndLastSendMessageAsync(userId);

            List<ChatPersonDto> peopleForAnother = await _chatService.GetUnreadAndLastSendMessageAsync(anotherUserId);

            await Clients.Caller.SendAsync("people", peopleForThis);

            await Clients.OthersInGroup(chatId.ToString()).SendAsync("people", peopleForAnother);
        }

        public async Task SendMessageAsync(NewMessageDto message)
        {
            await EmitLog("Client " + Context.ConnectionId + " said: " + message, message.ChatId.ToString());

            await _chatService.SendMessageAsync(message);

            await Clients.Group(message.ChatId.ToString()).SendAsync("message", message);
        }

        public async Task ReadMessages(long chatId, long userId)
        {
            var messages = await _chatService.SetMessagesAsRead(chatId, userId);

            await GetPeopleAsync(chatId, userId);
        }

        private async Task EmitLog(string message, string chatId)
        {
            await Clients.Group(chatId).SendAsync("log", "[Server]: " + chatId);
        }
    }
}