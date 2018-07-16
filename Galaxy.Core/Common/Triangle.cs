using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Galaxy.Core.Contracts;
using Galaxy.Core.Models;
using Galaxy.Core.Common;

namespace Galaxy.Core.Common
{
    public class Triangle : IGeometric
    {

        private List<Planet> planets;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="planets">Referencia a los planetas de la galaxia</param>
        public Triangle(List<Planet> planets) { this.planets = planets; }


        /// <summary>
        /// Determina el permietro del triangulo que forman los tres planetas.
        /// Mide los segmentos del triangulo formado por los tres planetas.
        /// Utilza el teorema de pitagoras r^2 = (a^2 + b^2) 
        /// </summary>
        /// <returns></returns>
        public double getPerimeter()
        {
            var segmentA = Math.Sqrt(Math.Pow((this.planets[1].x - this.planets[0].x), 2) + Math.Pow((this.planets[1].y - this.planets[0].y), 2));
            var segmentB = Math.Sqrt(Math.Pow((this.planets[2].x - this.planets[1].x), 2) + Math.Pow((this.planets[2].y - this.planets[1].y), 2));
            var segmentc = Math.Sqrt(Math.Pow((this.planets[2].x - this.planets[0].x), 2) + Math.Pow((this.planets[2].y - this.planets[0].y), 2));

            return segmentA + segmentB + segmentc;
        }

        /// <summary>
        /// Determina si el centro esta dentro del triangulo que forman los tres planetas.
        /// </summary>
        public bool IsCenterInside()
        {
            var tita1 = this.planets[0].AngularPosition;
            var tita2 = this.planets[1].AngularPosition;
            var tita3 = this.planets[2].AngularPosition;

            List<int> absoluteAnguleDiference = new List<int>(new int[] { Math.Abs(tita1 - tita2), Math.Abs(tita2 - tita3), Math.Abs(tita1 - tita3) });

            return absoluteAnguleDiference.Count(x => x > Constants.RADIAN_UNIT) == 1;
            
         }    
    }
}
