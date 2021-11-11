using Microsoft.AspNetCore.SignalR; 


namespace EasyGoServer.Hubs
{
    public class PruebaHub : Hub
    {
        public async Task SendState(string state)
        {
            await Clients.Others.SendAsync("ReceiveState", state);
        }
    }
}
