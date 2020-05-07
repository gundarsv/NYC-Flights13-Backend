using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Models
{
    public class TemperatureAtOriginDTO
    {
        public float TemperatureInFahrenheit { get; set; }

        public float TemperatureInCelsius { get; set; }

        public DateTime DateTime { get; set; }

        public TemperatureAtOriginDTO()
        {

        }
    }
}
