using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Core.Models
{
    public class Sun : Star
    {
        public Sun () : base ("Sun")
        {
            // Establece los valores cartesianos de X e Y en cero ya que el sol es el centro de la galaxia.
            this.x = 0;
            this.y = 0;
        }
    }
}
