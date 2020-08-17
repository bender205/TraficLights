using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static TraficLightsRazorPages.Models.IColorChangadable;

namespace TraficLightsRazorPages.Models
{
    public class TrafficLight : IColorChangadable
    {
        private static TrafficLight _traficLight;
        public TrafficLight() { }
        

        public static TrafficLight GetTrafficLight()
        {
            if(_traficLight is null)
            {
                _traficLight = new TrafficLight();
            }
            return _traficLight;

            
        }

        public Colors CurrentColor { get; set; } = Colors.red;
     
        public void NextColor()
        {
            if (this.CurrentColor == Colors.red)
            {
                this.CurrentColor = Colors.green;
            }
            else if (CurrentColor == Colors.green)
            {
                this.CurrentColor = Colors.red;
            }

        }

    }
}
