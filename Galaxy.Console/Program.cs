﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Models;
using Galaxy.Core.Common;

namespace Galaxy.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var myGalaxy = new Galaxy.Core.Models.Galaxy(new PlanetsSetup());
            var information = myGalaxy.Simulate(365*10);

            int a = 10;

        }
    }
}
    