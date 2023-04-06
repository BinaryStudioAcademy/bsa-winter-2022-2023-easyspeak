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
            string chatId = message.ChatId.ToString();

            await EmitLog("Client " + Context.ConnectionId + " said: " + message, chatId);

            await _chatService.SendMessageAsync(message);

            await Clients.OthersInGroup(chatId).SendAsync("message", message);
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
