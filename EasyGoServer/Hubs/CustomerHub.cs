using Microsoft.AspNetCore.SignalR;
using LibClassEasyGo;


namespace EasyGoServer.Hubs
{
    public class CustomerHub : Hub
    {
        public async Task SendTravel(object travel)
        {
            await Clients.Others.SendAsync("ReceiveTravel", travel);
        }
    }
}
