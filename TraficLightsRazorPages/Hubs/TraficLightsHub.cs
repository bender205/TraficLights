using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TraficLightsRazorPages.Models;
using static TraficLightsRazorPages.Models.IColorChangadable;

namespace TraficLightsRazorPages.Hubs
{
    public class TraficLightsHub : Hub
    {
        public async Task SendColor()
        {

            TrafficLight traficLight = TrafficLight.GetTrafficLight();
            traficLight.NextColor();
            await Clients.All.SendAsync("ReceiveColor", traficLight.CurrentColor.ToString());
        }
    }
}
