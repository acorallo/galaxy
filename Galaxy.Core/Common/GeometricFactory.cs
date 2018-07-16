using System;
using System.Collections.Generic;
using System.Text;
using Galaxy.Core.Models;
using Galaxy.Core.Contracts;
using Galaxy.Core.Common;
using Galaxy.Core.Exceptions;

namespace Galaxy.Core.Common
{
    public class GeometricFactory
    {

        private GeometricFactory() { }

        /// <summary>
        /// Genera una instancia del objeto de acuerdo a la cantidad de planetas que tiene el sistema.
        /// Actualemente soporta un sistems de 3 planetas pero eventualemente se podría extender el comportamiento para soporte de otros sistemas diferentes.
        /// Si el sistema tiene una cantidad de angulos distinta de tres se genera una excepcion Ad Hoc.
        /// </summary>
        /// <param name="planets">Referencia a los planetas de la galaxia</param>
        /// <returns></returns>
        public static IGeometric GetGeometric (List<Planet> planets)
        {
            IGeometric resultGeometric = null;

            switch (planets.Count)
            {
                case 3:
                    resultGeometric = new Triangle(planets);
                    break;
                default:
                    throw new GeometricModelNotSupported(planets.Count);
                    
            }

            return resultGeometric;
        }
    }
}
