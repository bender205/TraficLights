using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraficLightsRazorPages.Models
{
    public interface IColorChangadable
    {
        public enum Colors
        {
            red,
            yellow,
            green
        }
        public abstract void NextColor();
        public abstract Colors CurrentColor { get; set; }


    }
}
