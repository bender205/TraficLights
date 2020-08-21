using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TraficLightsRazorPages.Core.Hubs;
using TraficLightsRazorPages.Core.Models;
using TraficLightsRazorPages.Core.TrafficLights.Queries;

namespace TraficLightsRazorPages.Controllers
{
    [Route("Light")]
    public class LightController : Controller
    {
        private readonly TrafficLight _traficLight;
        private readonly IMediator _mediator;

        private readonly IHubContext<TraficLightsHub> _hubContext;
     /*   private readonly TraficLightsContext _lightsContext;*/
        public LightController(IHubContext<TraficLightsHub> hubContext, /*TraficLightsContext dbContext,*/
            TrafficLight trafficLight, IMediator mediator)
        {
            _traficLight = trafficLight;
            _mediator = mediator;
            this._hubContext = hubContext;
            
            /*
            this._lightsContext = dbContext;*/
        }
        public IActionResult Index()
        {
            ViewBag.Color = _traficLight.CurrentColor.ToString();
            return View(ViewBag);
        }

        [HttpPost("nextcolor")]
        public async Task<IActionResult> NextColor()
        {/*
            _traficLight.NextColor();//calling notifacation */
            _mediator.Send(new ChangeColorCommand());

            ViewBag.Color = _traficLight.CurrentColor.ToString();
            await _hubContext.Clients.All.SendAsync("ReceiveColor", _traficLight.CurrentColor.ToString());

            return NoContent();
        }
    }
}
