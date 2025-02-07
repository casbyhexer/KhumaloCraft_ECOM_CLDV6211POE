using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace KhumalocraftEmporium_ST10069127_CLDV6211POE.Hubs
{
    public class OrderHub : Hub
    {
        public async Task SendOrderUpdate(string message)
        {
            await Clients.All.SendAsync("ReceiveOrderUpdate", message);
        }
    }
}
