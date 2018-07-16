using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Core.Common
{
    class Constants
    {

        public const double RADIAN_UNIT = 180.0;
        public const double QUADRANT_UNIT = 90.0;
        public const int RADIAN = 360;

        // Posicion inicial de los planetas.
        public static readonly string FERENGI_NAME = "Ferengi";
        public static readonly int FERENGI_SUN_DISTANCE = 500;
        public static readonly int FERENGI_INITIAL_POSITION = 0;
        public static readonly int FERENGI_ANGLE_STEP_DATE = 1;
        public static bool FERENGI_CLOCKWISE = true;

        public static readonly string BETASOIDE_NAME = "Betasoide";
        public static readonly int BETASOIDE_SUN_DISTANCE = 2000;
        public static readonly int BETASOIDE_INITIAL_POSITION = 0;
        public static readonly int BETASOISE_ANGLE_STEP_DATE = 3;
        public static bool BETASOIDE_CLOCKWISE = true;

        public static readonly string VULCANO_NAME = "Vulcano";
        public static readonly int VULCANO_SUN_DISTANCE = 1000;
        public static readonly int VULCANO_INITIAL_POSITION = 0;
        public static readonly int VULCANO_ANGLE_STEP_DATE = 5;
        public static bool VULCANO_CLOCKWISE = false;

        #region Text

        #region Exception Text

        public static readonly string UNKNOW_EXCEPTION = "Unknow exception accurs.";
        public static readonly string AGE_EXCEPTION = "Age value must be positive";
        public static readonly string GEOMETRIC_MODEL_EXCEPTION_NOT_SUPPORTED_EXCEPTION = "Geometric is not supported for a {0}-plants system";

        #endregion Exceltion Text

        #endregion Text


    }
}
