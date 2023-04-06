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

        public async Task SendMessageAsync(string text, int chatId, int userId, string createdAt)
        {
            var message = new NewMessageDto();

            message.Text = text;
            message.ChatId = chatId;
            message.IsDeleted = false;
            message.IsRead = false;

            await EmitLog("Client " + Context.ConnectionId + " said: " + message, chatId.ToString());

            await _chatService.SendMessageAsync(message);

            await Clients.OthersInGroup(chatId.ToString()).SendAsync("message", message);
        }

        public async Task GetMessageAsync()
        {

        }

        private async Task EmitLog(string message, string chatId)
        {
            await Clients.Group(chatId).SendAsync("log", "[Server]: " + chatId);
        }
    }
}
