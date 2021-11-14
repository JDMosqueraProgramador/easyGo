using Microsoft.AspNetCore.SignalR;


namespace EasyGoServer.Hubs
{
    public class TravelHub : Hub
    {

        private string _AvailableGroupName = "available";

        public async Task SendTravel(int idUser, string customerName, double[] startPlace, double[] endPlace)
        {
            //Context.UserIdentifier = idUser;
            await Clients.Group(_AvailableGroupName).SendAsync("ReceiveTravel", idUser, customerName, startPlace, endPlace, DateTime.Now, Context.ConnectionId);
        }

        public async Task CancelTravel(int idUser, string customerName)
        {
            await Clients.Group(_AvailableGroupName).SendAsync("RemoveTravel", idUser, customerName);
        }

        // Accepted travel ------------------------------------------------------------
        public async Task AcceptTravel(int idDriver, string connectId, int idTravel)
        {
            string groupName = $"{idDriver}{connectId}";
            // string driverConnection = Context.ConnectionId;
            await this.AddGroup(groupName);
            await Clients.Client(connectId).SendAsync("AcceptedTravel", idDriver, groupName, idTravel);

        }

        public async Task SendPosition(double latitude, double longitude, string groupName)
        {
            await Clients.OthersInGroup(groupName).SendAsync("ChangePosition", latitude, longitude);
        }

        public async Task CancelAcceptedTravel(string groupName, int idTravel)
        {
            await Clients.OthersInGroup(groupName).SendAsync("CancelAcceptTravel", groupName, idTravel);
            await RemoveGroup(groupName);
        }

        public async Task SendInStart(string groupName)
        {
            await Clients.OthersInGroup(groupName).SendAsync("ReceiveInStart");
        }

        public async Task StartTravel(string groupName)
        {
            await Clients.OthersInGroup(groupName).SendAsync("StartedTravel");
        }

        public async Task FinishTravel(string groupName)
        {
            await Clients.OthersInGroup(groupName).SendAsync("FinishedTravel");
            await RemoveGroup(groupName);
        }

        // Groups ----------------------------------------------------------------------

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
