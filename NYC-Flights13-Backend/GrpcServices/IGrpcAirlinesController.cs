using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NYC_Flights13_Backend.Models;

namespace NYC_Flights13_Backend.GrpcServices
{
    public interface IGrpcAirlinesController
    {
        public IEnumerable<Airline> GetAirlines();
    }
}
