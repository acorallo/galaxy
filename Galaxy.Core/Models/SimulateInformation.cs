using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.Core.Models
{
    public class SimulateInformation
    {
        public int DroughtPeriods { get; set; }
        public int BestPeriods { get; set; }
        public int RainsPeriod { get; set; }

        public SimulateInformation()
        {
            this.DroughtPeriods = 0;
            this.BestPeriods = 0;
            this.RainsPeriod = 0;            
        }

        public void CountPeriod(Wheather weatherType)
        {
            switch (weatherType)
            {
                case Wheather.Drought:
                    this.DroughtPeriods++;
                    break;
                case Wheather.Rains:
                    this.RainsPeriod++;
                    break;
                case Wheather.Best:
                    this.BestPeriods++;
                    break;
                default:
                    break;
            }
        }
        
        
    }
}
