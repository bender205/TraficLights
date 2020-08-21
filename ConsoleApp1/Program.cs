using DataAccess.Context;
using System;
using TraficLightsRazorPages.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TraficLightsContext trafic = new TraficLightsContext())
            {
                trafic.TraficLightsSet.Add(new TraficLightsEntity() { Color = "red", Time = DateTime.Now});
                Console.WriteLine(1);
                foreach (var v in trafic.TraficLightsSet)
                {
                    Console.WriteLine(v.Id + "  " + v.Color + " " + v.Time);
                }
                trafic.SaveChanges();
                Console.WriteLine(2);
/*
                foreach (var v in trafic.TraficLightsSet)
                {
                    Console.WriteLine(v.Id + "  " + v.Color + " " + v.Time);
                }*/
            }
        }
    }
}
