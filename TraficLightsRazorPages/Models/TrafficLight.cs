﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraficLightsRazorPages.Models
{
    public class TrafficLight
    {
        public TrafficLight() { }
        public TrafficLight(Colors color)
        {
            this.CurrentColor = color;
        }
        public enum Colors
        {
            red,
            orange,
            green
        }
        public Colors CurrentColor { get; set; } = Colors.red;
        public Colors PreviousColor { get; set; } = Colors.red;
        public void SetColor(Colors color)
        {
            this.CurrentColor = color;
        }
        private void setOrangeColor()
        {

        }
        public void ChangeColor()
        {

            if ( CurrentColor == Colors.orange && PreviousColor == Colors.red)
            {
                CurrentColor = Colors.green;
            }
            else if (CurrentColor == Colors.orange && PreviousColor == Colors.green)
            {
                CurrentColor = Colors.red;
            }

            /*
            switch (CurrentColor)
            {
                case Colors.red:
                    this.CurrentColor = Colors.orange;
                    break;

                case Colors.orange:
                    this.CurrentColor = Colors.green;
                    break;

                case Colors.green:
                    this.CurrentColor = Colors.red;
                    break;
               *//* default:
                    this.CurrentColor = Colors.red;
                    break;*//*

            }*/


        }

    }
}
