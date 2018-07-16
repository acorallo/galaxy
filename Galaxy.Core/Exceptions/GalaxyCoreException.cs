using System;
using System.Collections.Generic;
using System.Text;
using Galaxy.Core.Common;

namespace Galaxy.Core.Exceptions
{
    class GalaxyCoreException : ApplicationException
    {
        public GalaxyCoreException(string errorMessage) : base(errorMessage) { }
        public GalaxyCoreException() : base (Constants.UNKNOW_EXCEPTION) { }
    }
}
