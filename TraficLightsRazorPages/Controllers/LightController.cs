using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TraficLightsRazorPages.Hubs;
using TraficLightsRazorPages.Models;

namespace TraficLightsRazorPages.Controllers
{
    [Route("Light")]
    public class LightController : Controller
    {
        TrafficLight traficLight = TrafficLight.GetTrafficLight();
        IHubContext<TraficLightsHub> _hubContext;
        public LightController(IHubContext<TraficLightsHub> hubContext)
        {
            this._hubContext = hubContext;
        }
        public IActionResult Index()
        {
            ViewBag.Color = traficLight.CurrentColor.ToString();
            return View(ViewBag);
        }
        /*
         [HttpPost]
        public IActionResult NextColor()
        {
            traficLight.NextColor();
            ViewBag.Color = traficLight.CurrentColor.ToString();
            return View("Index", ViewBag);

        }*/
        /*[HttpPost]
        [Route("Light/NextColor")]
        public IActionResult NextColor()
        {
            traficLight.NextColor();
            ViewBag.Color = traficLight.CurrentColor.ToString();
            return View("Index", ViewBag);

        }*/
        /*
                [HttpPost]
                public async Task<IActionResult> NextColor()
                {
                    traficLight.NextColor();
                    ViewBag.Color = traficLight.CurrentColor.ToString();
                   await _hubContext.Clients.All.SendAsync(traficLight.CurrentColor.ToString());
                    return View("Index", ViewBag);

                }*/
        [HttpPost("nextcolor")]
        public void  NextColor()
        {
            traficLight.NextColor();
            ViewBag.Color = traficLight.CurrentColor.ToString();
             _hubContext.Clients.All.SendAsync("ReceiveColor", traficLight.CurrentColor.ToString());

        }
    }
}
