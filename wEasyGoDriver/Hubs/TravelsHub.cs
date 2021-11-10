using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace wEasyGoDriver.Hubs
{
    internal class TravelsHub : Hub
    {
        public async Task sendState(string state)
        {
            await Clients.Others.SendAsync("ReceiveState", state);
        }
    }
}
