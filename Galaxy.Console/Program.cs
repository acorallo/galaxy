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
        private const string SIMULATION_COMMAND = "-sim";
        private const string NEXT_DAY_COMMAND = "-nextday";

        static void Main(string[] args)
        {
            System.Console.WriteLine("Ejecutando Galaxia ...");
            ExcecuteParameters(args);
            
        }

        static void RunSimulation(int days)
        {
            var myGalaxy = new Galaxy.Core.Models.Galaxy(new PlanetsSetup());
            var information = myGalaxy.Simulate(days);
            ShowInfomation(information);

            System.Console.WriteLine(String.Empty);
            System.Console.WriteLine("Fin del programa. Presione una tecla para salir.");
            System.Console.Read();
        }

        static void RunNextDay()
        {
            if(Galaxy.Core.Models.Galaxy.RunNextDay(new PlanetsSetup()))
            {
                System.Console.WriteLine("La base de datos se ha actualizado correctamente");
            }else
            {
                System.Console.WriteLine("La base de datos no se ha actualizado");
            }
        }
        
        private void ShowErrors(Exception ex)
        {
            System.Console.WriteLine("El programa se ha terminado de ejecutar con errors:");
            System.Console.WriteLine(string.Format("Mensaje de error: {0}", ex.Message));
                
        }

        private static void ShowInfomation(SimulateInformation information)
        {
            System.Console.WriteLine("Informacion de la Galaxia:");
            System.Console.WriteLine(String.Empty);
            System.Console.WriteLine("Periodos de Sequedad: {0}", information.DroughtPeriods);
            System.Console.WriteLine("Periodos de lluvia: {0}, alcanzando un pico máximo el día {1}", information.RainsPeriod, information.MaxTrianglePerimeterDay);
            System.Console.WriteLine("Periodos de Presión y Temperatura Optima: {0}", information.BestPeriods);
        }

        private static void ExcecuteParameters (string[] args)
        {
            if (args.Count() > 0)
            {
                switch (args[0])
                {
                    case SIMULATION_COMMAND:
                        {
                            int days;
                            if (args.Count() > 1 && Int32.TryParse(args[1], out days) && days > 0)
                            {
                                RunSimulation(days);
                            }
                            else
                            {
                                System.Console.WriteLine("El comando sim esperaba como segundo parametro un entero positivo");
                            }
                        }
                        break;
                    case NEXT_DAY_COMMAND:
                        {
                            RunNextDay();
                        }
                        break;
                    default:
                        {
                            System.Console.WriteLine("Command not found.");
                        }
                        break;
                }
            }
            else
            {
                System.Console.WriteLine("Command not found.");
            }
        }
   
    }
}
    