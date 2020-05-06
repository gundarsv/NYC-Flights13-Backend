using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Models
{
    public class DestinationsForOriginDTO
    {
        public int NumberOfFlights { get; set; }
        
        public string Destination { get; set; }

        public string Origin { get; set; }

        public DestinationsForOriginDTO()
        {
        }
    }
}
