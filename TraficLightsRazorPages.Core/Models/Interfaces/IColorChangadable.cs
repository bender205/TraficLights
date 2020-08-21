using System;
using System.Collections.Generic;
using System.Text;

namespace TraficLightsRazorPages.Core.Models.Interfaces
{
    public interface IColorChangadable
    {
        public enum Colors
        {
            red,
            yellow,
            green
        }/*
        public abstract void NextColor();*/
        public abstract Colors CurrentColor { get; set; }
    }
}
