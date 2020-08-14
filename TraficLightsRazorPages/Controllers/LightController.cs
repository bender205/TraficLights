using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TraficLightsRazorPages.Models;

namespace TraficLightsRazorPages.Controllers
{
    public class LightController : Controller
    {
        TrafficLight _trafficLight = new TrafficLight(); 
        public IActionResult Index()
        {
            return View();
        }
    }
}
