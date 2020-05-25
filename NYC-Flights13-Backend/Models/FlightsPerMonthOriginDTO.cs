using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Models
{
    public class FlightsPerMonthOriginDTO
    {
        public int Month { get; set; }

        public int Flights { get; set; }

        public string Origin { get; set; }

        public FlightsPerMonthOriginDTO()
        {
        }
    }
}
