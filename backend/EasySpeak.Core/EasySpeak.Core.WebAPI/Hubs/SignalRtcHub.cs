using EasySpeak.Core.Common.DTO.User;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

namespace EasySpeak.Core.WebAPI.Hubs
{
    public class SignalRtcHub: Hub
    {
        public async Task NewUser(string username)
        {
            var userInfo = new UserConnectionDto() { UserName = username, ConnectionId = Context.ConnectionId };
            await Clients.Others.SendAsync("NewUserArrived", JsonSerializer.Serialize(userInfo));
        }

        public async Task HelloUser(string username, string user)
        {
            var userInfo = new UserConnectionDto() { UserName = username, ConnectionId = Context.ConnectionId };
            await Clients.Client(user).SendAsync("UserSaidHello", JsonSerializer.Serialize(userInfo));
        }
        public async Task SendSignal(string signal, string user)
        {
            await Clients.Client(user).SendAsync("SendSignal", Context.ConnectionId, signal);
        }
        public override async Task OnDisconnectedAsync(System.Exception? exception)
        {
            await Clients.All.SendAsync("UserDisconnect", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
