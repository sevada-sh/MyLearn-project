using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using MyLearn.Application.Interfaces;
using MyLearn.Domain.Models;

namespace MyLearn.Mvc
{
    public class ChatHub : Hub
    {
        private readonly IChatRoomService _chatroomService;
        private readonly IHubContext<AgentHub> _agentHub;
        public ChatHub(IChatRoomService chatroomService, IHubContext<AgentHub> agentHub)
        {
            _chatroomService = chatroomService;
            _agentHub = agentHub;
        }

        public override async Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                await base.OnConnectedAsync();
                return;
            }

            var roomId = await _chatroomService.CreateRoom(Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());

            await Clients.Caller.SendAsync("ReceiveMessage",
                "TopLearn Support",
                DateTimeOffset.UtcNow,
                "Hello! How can we help you");

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string name, string text)
        {
            var roomId = await _chatroomService.GetRoomForConnectionId(Context.ConnectionId);
            var message = new ChatMessage
            {
                SenderName = name,
                text = text,
                SendAt = DateTimeOffset.Now
            };

            await _chatroomService.AddMessage(roomId, message);

            await Clients.Group(roomId.ToString()).SendAsync("ReceiveMessage", message.SenderName, message.SendAt, message.text);
        }

        public async Task SetName(string visitorName)
        {
            var roomName = $"Chat with {visitorName} from the web";

            var roomId = await _chatroomService.GetRoomForConnectionId(Context.ConnectionId);

            await _chatroomService.SetRoomName(roomId, roomName);

            await _agentHub.Clients.All.SendAsync("ActiveRooms", await _chatroomService.GetAllRooms());
        }

        [Authorize]
        public async Task JoinGroup(Guid roomId)
        {
            if (roomId == Guid.Empty)
            {
                throw new ArgumentException("Invalid Room Id");
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        [Authorize]
        public async Task LeaveRoom(Guid roomId)
        {
            if (roomId == Guid.Empty)
            {
                throw new ArgumentException("Invalid Room Id");
            }

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());

        }
    }
}
