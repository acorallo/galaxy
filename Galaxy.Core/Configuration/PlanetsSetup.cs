using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Galaxy.Core.Contracts;
using GM = Galaxy.Core.Models;
using Galaxy.Core.Common;
using System.Web.Script.Serialization;

namespace Galaxy.Core.Configuration
{
    public class PlanetsSetup : IGalaxySetup
    {

        public List<GM.Planet> getPlanets()
        {
            List<GM.Planet> resultList = new List<GM.Planet>();

            var jserializer = new JavaScriptSerializer();
            var planets = jserializer.DeserializeFrom<List<Planet>>(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constants.GALAXY_CONFIGURATION_FILE_NAME));

            foreach(var planet in planets)
            {
                resultList.Add(new GM.Planet(planet.Name, planet.InitialPosition, planet.AngularStepDay, planet.SunDistance, planet.Clockwise));
            }
            
            return resultList;
        }
    }
}
