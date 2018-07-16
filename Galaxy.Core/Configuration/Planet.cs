using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Core.Configuration
{
    public class Planet
    {
        public string Name { get; set; }
        public int SunDistance { get; set; }
        public int InitialPosition { get; set; }
        public int AngularStepDay { get; set; }
        public bool Clockwise { get; set; }
    }
}
