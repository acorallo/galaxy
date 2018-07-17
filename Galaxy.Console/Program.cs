using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Models;
using Galaxy.Core.Common;
using Galaxy.Core.Configuration;


namespace Galaxy.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var myGalaxy = new Galaxy.Core.Models.Galaxy(new PlanetsSetup());            
            var information = myGalaxy.Simulate(50);
            ShowInfomation(information);

            System.Console.WriteLine(String.Empty);
            System.Console.WriteLine("Fin del programa. Presione una tecla para salir.");
            System.Console.Read();
        }

        static void ShowInfomation(SimulateInformation information)
        {
            System.Console.WriteLine("Informacion de la Galaxia:");
            System.Console.WriteLine(String.Empty);
            System.Console.WriteLine("Periodos de Sequedad: {0}", information.DroughtPeriods);
            System.Console.WriteLine("Periodos de lluvia: {0}, alcanzando un pico máximo el día {1}", information.RainsPeriod, information.MaxTrianglePerimeterDay);
            System.Console.WriteLine("Periodos de Presión y Temperatura Optima: {0}", information.BestPeriods);
        }
    }
}
    