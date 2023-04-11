using EasySpeak.Core.DAL.Context;
using EasySpeak.Core.DAL.Entities;
using Microsoft.AspNetCore.SignalR;

namespace EasySpeak.Communicator.WebAPI.Services
{
    public class SignalRtcHub : Hub
    {
        private readonly EasySpeakCoreContext _context;
        private static readonly Dictionary<string, string> ConnectedUsers = new Dictionary<string, string>();
        static readonly Dictionary<string, List<string>> ConnectedClients = new Dictionary<string, List<string>>();

        public SignalRtcHub(EasySpeakCoreContext context)
        {
            _context = context;
        }

        public void Connect(string email)
        {
            ConnectedUsers[email] = Context.ConnectionId;
        }

        public void Disconnect(string email)
        {
            ConnectedUsers.Remove(email);
        }

        public async Task CallUser(int chatId, string calleeEmail, int callerId, string callerEmail, string callerFullName, string callerImgPath)
        {
            ConnectedUsers[callerEmail] = Context.ConnectionId;
            var connectionId = ConnectedUsers[calleeEmail];

            var roomName = Guid.NewGuid().ToString();

            await Clients.Client(connectionId).SendAsync("startCall", chatId, callerId, callerEmail, callerFullName, callerImgPath, roomName);
        }

        public async Task AcceptCall(int chatId, int callerId, string callerEmail, string calleeEmail, string calleeFullName, string roomName)
        {
            var connectionId = ConnectedUsers[callerEmail];

            await Clients.Client(connectionId).SendAsync("accept", chatId, callerId, calleeEmail, calleeFullName, roomName);
        }

        public async Task RejectCall(string email)
        {
            var connectionId = ConnectedUsers[email];
            await Clients.Client(connectionId).SendAsync("reject");
        }

        public async Task EndCall(int chatId, int userId, DateTime startedAt, DateTime finishedAt)
        {
            var call = new Call
            {
                ChatId = chatId, 
                StartedAt = startedAt,
                FinishedAt = finishedAt,
                CreatedAt = startedAt,
                CreatedBy = userId,
            };

            _context.Calls.Add(call);
            await _context.SaveChangesAsync();
        }

        public async Task SendMessage(object message, string roomName)
        {
            await EmitLog("Client " + Context.ConnectionId + " said: " + message, roomName);

            await Clients.OthersInGroup(roomName).SendAsync("message", message);
        }

        public async Task CreateOrJoinRoom(string roomName)
        {
            CreateRoom(roomName);

            AddClientToRoom(roomName);

            await EmitJoinRoom(roomName);

            var numberOfClients = ConnectedClients[roomName].Count;

            if (numberOfClients == 1)
            {
                await EmitCreated();
                await EmitLog("Client " + Context.ConnectionId + " created the room " + roomName, roomName);
            }
            else
            {
                await EmitJoined(roomName);
                await EmitLog("Client " + Context.ConnectionId + " joined the room " + roomName, roomName);
            }

            await EmitLog("Room " + roomName + " now has " + numberOfClients + " client(s)", roomName);
        }

        private static void CreateRoom(string roomName)
        {
            if (!ConnectedClients.ContainsKey(roomName))
            {
                ConnectedClients.Add(roomName, new List<string>());
            }
        }

        private void AddClientToRoom(string roomName)
        {
            if (!ConnectedClients[roomName].Contains(Context.ConnectionId))
            {
                ConnectedClients[roomName].Add(Context.ConnectionId);
            }
        }

        public async Task LeaveRoom(string roomName)
        {
            await EmitLog("Received request to leave the room " + roomName + " from a client " + Context.ConnectionId, roomName);

            await DeleteClientFromRoom(roomName);

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        private async Task DeleteClientFromRoom(string roomName)
        {
            if (ConnectedClients.ContainsKey(roomName) && ConnectedClients[roomName].Contains(Context.ConnectionId))
            {
                ConnectedClients[roomName].Remove(Context.ConnectionId);
                await EmitLog("Client " + Context.ConnectionId + " left the room " + roomName, roomName);
                await RemoveRoomIfEmpty(roomName);
            }
        }

        private async Task RemoveRoomIfEmpty(string roomName)
        {
            if (ConnectedClients[roomName].Count == 0)
            {
                ConnectedClients.Remove(roomName);
                await EmitLog("Room " + roomName + " is now empty - resetting its state", roomName);
            }
        }

        private async Task EmitJoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        private async Task EmitCreated()
        {
            await Clients.Caller.SendAsync("created");
        }

        private async Task EmitJoined(string roomName)
        {
            await Clients.Group(roomName).SendAsync("joined");
        }

        private async Task EmitLog(string message, string roomName)
        {
            await Clients.Group(roomName).SendAsync("log", "[Server]: " + message);
        }
    }
}
