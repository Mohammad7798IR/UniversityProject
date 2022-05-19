using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Shop.Application.Interfaces;
using Shop.Domain.Entities.Chat;

namespace MyChat
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatRoomService;
        private readonly IHubContext<AgentHub> _agentHub;

        public ChatHub(IChatService chatRoomService,IHubContext<AgentHub> agentHub)
        {
            _chatRoomService = chatRoomService;
            _agentHub = agentHub;
        }
        public override async Task OnConnectedAsync()
        {
         

            var roomId = await _chatRoomService.CreateRoom(Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());

            await Clients.Caller.SendAsync("ReciveMessage",
                "TopLearn Support",
                DateTimeOffset.UtcNow,
                "Hello ! What can we help you with today ?");

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string name, string text)
        {
            var roomId = await _chatRoomService.GetRoomForConnectionId(Context.ConnectionId);
            var message = new ChatMessage
            {
                SenderName = name,
                Text = text,
                SendAt = DateTimeOffset.Now
            };

            await _chatRoomService.AddMessage(roomId, message);


            await Clients.Group(roomId.ToString()).SendAsync("ReceiveMessage", message.SenderName, message.SendAt, message.Text);
        }

        public async Task SetName(string visitorName)
        {
            var roomName = $"Chat With {visitorName} from the web .";

            var roomId = await _chatRoomService.GetRoomForConnectionId(Context.ConnectionId);

            await _chatRoomService.SetRoomName(roomId, roomName);
            await _agentHub.Clients.All.SendAsync("ActiveRooms", await _chatRoomService.GetAllRooms());
        }

        [Authorize(Roles = "AplicationSupport")]
        public async Task JoinRoom(Guid roomId)
        {
            if (roomId == Guid.Empty)
            {
                throw  new ArgumentException("Invalid Room ID");
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        [Authorize(Roles = "AplicationSupport")]
        public async Task LeaveRoom(Guid roomId)
        {
            if (roomId == Guid.Empty)
            {
                throw new ArgumentException("Invalid Room ID");
            }

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());
        }
    }
}
