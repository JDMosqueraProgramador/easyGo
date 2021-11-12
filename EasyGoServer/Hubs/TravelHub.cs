using Microsoft.AspNetCore.SignalR; 


namespace EasyGoServer.Hubs
{
    public class TravelHub : Hub
    {
        public async Task SendTravel(string TravelJSON)
        {
            await Clients.Others.SendAsync("ReceiveTravel", TravelJSON);
        }
    }
}
