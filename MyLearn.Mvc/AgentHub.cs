using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using MyLearn.Application.Interfaces;
using MyLearn.Domain.Models;

namespace MyLearn.Mvc
{
    [Authorize]
    public class AgentHub : Hub
    {
        private readonly IChatRoomService _chatroomService;
        private readonly IHubContext<ChatHub> _chatHub;
        public AgentHub(IChatRoomService chatroomService, IHubContext<ChatHub> chatHub)
        {
            _chatroomService = chatroomService;
            _chatHub = chatHub;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ActiveRoom", await _chatroomService.GetAllRooms());
            await base.OnConnectedAsync();
        }

        public async Task SendAgentMessage(Guid roomId, string text)
        {
            var message = new ChatMessage
            {
                SendAt = DateTimeOffset.Now,
                SenderName = Context.User.Identity.Name,
                text = text
            };
            await _chatroomService.AddMessage(roomId, message);

            await _chatHub.Clients.Group(roomId.ToString())
                .SendAsync("ReceiveMessage", message.SendAt, message.SenderName, message.text);
        }

        public async Task LoadHistory(Guid roomId)
        {
            var history = await _chatroomService.GetMessagehistory(roomId);
            await Clients.Caller.SendAsync("ReceiveMessages", history);
        }
    }
}
