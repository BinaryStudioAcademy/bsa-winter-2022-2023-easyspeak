using Microsoft.AspNetCore.SignalR;
using EasySpeak.Notifier.Hubs.Interfaces;

namespace EasySpeak.Notifier.Hubs
{
    public class BroadcastHub : Hub<IBroadcastHubClient>
    {
    }
}