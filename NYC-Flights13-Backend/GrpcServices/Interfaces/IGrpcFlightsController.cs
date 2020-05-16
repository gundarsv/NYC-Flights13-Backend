using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFlights;
using NYC_Flights13_Backend.Models;

namespace NYC_Flights13_Backend.GrpcServices.Interfaces
{
    public interface IGrpcFlightsController
    {
        public IEnumerable<FlightDTO> GetFlights();

        public FlightsPerMonthDTO GetNumberOfFlights(int monthNumber);

        public IEnumerable<FlightsPerMonthDTO> GetNumberOfFlightsInMonths(List<int> monthNumbers);

        public IEnumerable<DestinationsForOriginDTO> GetTop10DestinationsForOrigin(string origin);

        public AirtimeAtOriginDTO GetAirtimeAtOrigin(string origin);
    }
}
