using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Data.Datamodels
{
    public class GalaxyDataModel
    { 
        public int Id { get; set; }
        public int Day { get; set; }
        public string Weather { get; set; }
        public double Perimeter { get; set; }
        public bool SunIn { get; set; }
    }
}
