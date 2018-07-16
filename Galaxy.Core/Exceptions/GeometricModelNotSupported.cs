using System;
using System.Collections.Generic;
using System.Text;
using Galaxy.Core.Common;

namespace Galaxy.Core.Exceptions
{
    class GeometricModelNotSupported : GalaxyCoreException
    {
        public GeometricModelNotSupported(int planetsCount) : base(string.Format(Constants.GEOMETRIC_MODEL_EXCEPTION_NOT_SUPPORTED_EXCEPTION, planetsCount.ToString()))
        {

        }
    }
}
