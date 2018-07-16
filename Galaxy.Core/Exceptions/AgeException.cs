using System;
using System.Collections.Generic;
using System.Text;
using Galaxy.Core.Common;

namespace Galaxy.Core.Exceptions
{
    class AgeException : GalaxyCoreException
    {
        public AgeException() : base(Constants.AGE_EXCEPTION) { }
    }
}
