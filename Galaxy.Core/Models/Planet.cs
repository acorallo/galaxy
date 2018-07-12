using System;
using System.Collections.Generic;
using System.Text;
using Galaxy.Core.Common;

namespace Galaxy.Core.Models
{
    public class Planet : Start
    {

        

        /// <summary>
        /// Determina la posición angular.
        /// </summary>
        /// <param name="position">Angulo expresado en grados</param>
        public Planet(int position)
        {
            var myPostion = this.GetAxialPosition(Constants.QUADRANT_UNIT - position % Constants.QUADRANT_UNIT, 60);
            this.x = myPostion.x;
            this.y = myPostion.y;
        }
    }
}
