using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models = Galaxy.Core.Models;
using Galaxy.Core.Configuration;
using Galaxy.WebApi.Exceptions;

namespace Galaxy.WebApi.Controllers
{
    public class GalaxyController : ApiController
    {
        [HttpGet]
        public string Get(int id)
        {

            try
            {
                if (id < 0)
                    throw new DayParameterNotNegative();

                var planetSetup = new PlanetsSetup();
                var galaxy = new Models.Galaxy(planetSetup);
                galaxy.SetAge(id);
                return string.Concat("{\"dia\":", id, ",\"clima\":\"", galaxy.GetWheather(), "\"}");
            }
            catch(Exception ex)
            {
                return string.Concat("{Error\":\"",ex.Message, "\"}");
            }
            
        }
    }
}
