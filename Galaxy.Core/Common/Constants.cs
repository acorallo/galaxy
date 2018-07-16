using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Core.Common
{
    class Constants
    {

        // Configuration 
        public const string GALAXY_CONFIGURATION_FILE_NAME = "GalaxyConf.json";

        public const double RADIAN_UNIT = 180.0;
        public const double QUADRANT_UNIT = 90.0;
        public const int RADIAN = 360;

        public const int NULL_DAY = -1;
        
        #region Text

        #region Exception Text

        public static readonly string UNKNOW_EXCEPTION = "Unknow exception accurs.";
        public static readonly string AGE_EXCEPTION = "Age value must be positive";
        public static readonly string GEOMETRIC_MODEL_EXCEPTION_NOT_SUPPORTED_EXCEPTION = "Geometric is not supported for a {0}-plants system";

        #endregion Exceltion Text

        #endregion Text


    }
}
