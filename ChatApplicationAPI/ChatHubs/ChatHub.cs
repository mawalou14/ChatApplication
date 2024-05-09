using Microsoft.AspNetCore.SignalR;

namespace ChatApplicationAPI.ChatHubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userName, string message, DateTime date)
           => await Clients.All.SendAsync("RecieveMessage", userName, message, date);

        public async Task NewMessage(string userName)
           => await Clients.Others.SendAsync("NewMessage", userName);
    }
}
