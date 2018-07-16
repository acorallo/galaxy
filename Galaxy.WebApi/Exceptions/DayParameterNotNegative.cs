using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galaxy.WebApi.Exceptions
{
    public class DayParameterNotNegative : GalaxyWebapiException
    {
        private const string ErrorMsg = "El parametro Día debe ser un entero positivo";

        public DayParameterNotNegative() : base(ErrorMsg) { }
    }
}