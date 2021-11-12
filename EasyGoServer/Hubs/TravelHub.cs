using Microsoft.AspNetCore.SignalR;


namespace EasyGoServer.Hubs
{
    public class TravelHub : Hub
    {

        private string _AvailableGroupName = "available";
        public async Task SendTravel(int idUser, string customerName, string startPlace, string endPlace)
        {
            //Context.UserIdentifier = idUser;
            await Clients.Group(_AvailableGroupName).SendAsync("ReceiveTravel", idUser, customerName, startPlace, endPlace, Context.ConnectionId);
        }

        public async Task CancelTravel(int idUser, string customerName)
        {
            await Clients.Group(_AvailableGroupName).SendAsync("RemoveTravel", idUser, customerName);
        }

        public async Task AcceptTravel(int idDriver, string connectId)
        {
            string groupName = $"{idDriver}{connectId}";
            string driverConnection = Context.ConnectionId;
            await this.AddGroup(groupName);
            await Clients.Client(connectId).SendAsync("AcceptedTravel", idDriver, groupName, driverConnection);

        }

        public async Task AddAvailable()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, this._AvailableGroupName);
            // Clients.Group(_AvailableGroupName)
        }

        public async Task RemoveAvailable()
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, this._AvailableGroupName);
        }

        public async Task AddGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        } 

        public async Task RemoveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        }
    }
}
