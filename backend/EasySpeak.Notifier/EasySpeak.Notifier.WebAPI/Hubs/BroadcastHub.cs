using EasySpeak.Notifier.Hubs.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace EasySpeak.Notifier.WebAPI.Hubs
{
    public class BroadcastHub : Hub<IBroadcastHubClient>
    {
    }
}