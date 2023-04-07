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

        public async Task SendMessageAsync(NewMessageDto message)
        {
            await EmitLog("Client " + Context.ConnectionId + " said: " + message, message.ChatId.ToString());

            await _chatService.SendMessageAsync(message);

            await Clients.Group(message.ChatId.ToString()).SendAsync("message", message);
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
