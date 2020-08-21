using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TraficLightsRazorPages.Core.Models;
using TraficLightsRazorPages.Core.TrafficLights.Queries;

namespace TraficLightsRazorPages.Core.Hubs
{
    public class TraficLightsHub : Hub
    {
        private readonly TrafficLight _trafficLight;
        private readonly IMediator _mediator;

        public TraficLightsHub(TrafficLight trafficLight, IMediator mediator)
        {
            _trafficLight = trafficLight;
            _mediator = mediator;
        }

        public async Task SendColor()
        {
           /* an old code
            _traficLight.NextColor();
            await Clients.All.SendAsync("ReceiveColor", traficLight.CurrentColor.ToString());*/

           _mediator.Send(new ChangeColorCommand());
        }
    }
}
