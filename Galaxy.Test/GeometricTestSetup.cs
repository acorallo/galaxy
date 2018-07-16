using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Common;
using Galaxy.Core.Contracts;
using Galaxy.Core.Models;

namespace Galaxy.Test
{
    public class GeometricTestSetup : IGalaxySetup
    {
        public List<Planet> getPlanets()
        {
            List<Planet> list = new List<Planet>();

            list.Add(new Planet("Planet_1", 75, 1, 500, false));
            list.Add(new Planet("Planet_2", 142, 1, 1000, false));
            list.Add(new Planet("Planet_3", 285, 1, 2000, false));

            /*
            list.Add(new Planet("Planet_1", 105, 1, 500, false));
            list.Add(new Planet("Planet_2", 125, 1, 1000, false));
            list.Add(new Planet("Planet_3", 332, 1, 2000, false));
            */

            return list;
        }
    }
}
