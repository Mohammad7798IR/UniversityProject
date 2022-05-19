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

    [Authorize(Roles = "AplicationSupport")]
    public class AgentHub:Hub
    {
        private readonly IChatService _chatRoomService;
        private readonly IHubContext<ChatHub> _chatHub;

        public AgentHub(IChatService chatRoomService,IHubContext<ChatHub> chatHub)
        {
            _chatRoomService = chatRoomService;
            _chatHub = chatHub;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ActiveRooms", await _chatRoomService.GetAllRooms());
            await base.OnConnectedAsync();
        }

        public async Task SendAgentMessage(Guid roomId, string text)
        {
            var message = new ChatMessage
            {
                SendAt = DateTimeOffset.UtcNow,
                SenderName = Context.User.Identity.Name,
                Text = text
            };
            await _chatRoomService.AddMessage(roomId, message);

            await _chatHub.Clients.Group(roomId.ToString())
                .SendAsync("ReceiveMessage", message.SenderName, message.SendAt, message.Text);
        }

        public async Task LoadHistory(Guid roomId)
        {
            var history = await _chatRoomService.GetMessageHistory(roomId);
            await Clients.Caller.SendAsync("ReceiveMessages", history);
        }

    }
}
