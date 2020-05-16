using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Models
{
    public class DailyMeanTemperatureAtOriginDTO
    {
        public float DailyMeanTemperatureInFahrenheit { get; set; }

        public float DailyMeanTemperatureInCelsius { get; set; }

        public DateTime DateTime { get; set; }
    }
}
