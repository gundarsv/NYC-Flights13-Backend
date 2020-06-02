using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Models
{
    public class DepartureArrivalDelayAtOriginDTO
    {
        public float ArrivalDelay { get; set; }

        public float DepartureDelay { get; set; }

        public string Origin { get; set; }

        public DepartureArrivalDelayAtOriginDTO()
        {

        }
    }
}
