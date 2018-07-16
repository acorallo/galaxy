using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galaxy.WebApi.Exceptions
{
    public class GalaxyWebapiException : ApplicationException
    {
        public GalaxyWebapiException() { }
        public GalaxyWebapiException (string errorMsg) : base(errorMsg) { }
    }
}