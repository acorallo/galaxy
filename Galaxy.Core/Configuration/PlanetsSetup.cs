using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Galaxy.Core.Contracts;
using Galaxy.Core.Models;
using Galaxy.Core.Common;


namespace Galaxy.Core.Configuration
{
    public class PlanetsSetup : IGalaxySetup
    {

        public List<Planet> getPlanets()
        {

            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constants.GALAXY_CONFIGURATION_FILE_NAME);

            List<Planet> list = new List<Planet>();
            list.Add(new Planet(Constants.FERENGI_NAME, Constants.FERENGI_INITIAL_POSITION, Constants.FERENGI_ANGLE_STEP_DATE, Constants.FERENGI_SUN_DISTANCE, Constants.FERENGI_CLOCKWISE));
            list.Add(new Planet(Constants.BETASOIDE_NAME, Constants.BETASOIDE_INITIAL_POSITION, Constants.BETASOISE_ANGLE_STEP_DATE, Constants.BETASOIDE_SUN_DISTANCE, Constants.BETASOIDE_CLOCKWISE));
            list.Add(new Planet(Constants.VULCANO_NAME, Constants.VULCANO_INITIAL_POSITION, Constants.VULCANO_ANGLE_STEP_DATE, Constants.VULCANO_SUN_DISTANCE, Constants.VULCANO_CLOCKWISE));
            return list;
        }
    }
}
