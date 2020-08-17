using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TraficLightsRazorPages.Models;

namespace TraficLightsRazorPages.Controllers
{
    [Route("Light")]
    public class LightController : Controller
    {
        TrafficLight traficLight = TrafficLight.GetTrafficLight();

        public IActionResult Index()
        {
            ViewBag.Color = traficLight.CurrentColor.ToString();
            return View(ViewBag);
        }


        [HttpPost]
        public IActionResult NextColor()
        {
            traficLight.NextColor();
            ViewBag.Color = traficLight.CurrentColor.ToString();
            return View("Index", ViewBag);

            /* traficLight.NextColor();
             ViewBag.Color = traficLight.CurrentColor.ToString();
             if (ViewBag.Color == "red")
             {
                 return View("RedColor", ViewBag);
             }
             else
             {
                 return View("GreenColor", ViewBag);
             }*/



        }
    }
}
