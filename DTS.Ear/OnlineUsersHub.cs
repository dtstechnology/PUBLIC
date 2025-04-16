using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp;
using System.Threading.Tasks;

namespace DTS.Ear
{
    public class OnlineUsersHub : Hub
    {
        public async Task UserConnected(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }

        public async Task UserDisconnected(string userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }
    }
}
