using Flight = NYC_Flights13_Backend.Models.Flight;
using Empty = Google.Protobuf.WellKnownTypes.Empty;
using NYC_Flights13_Backend.GrpcServices.Interfaces;
using System.Collections.Generic;
using GrpcFlights;
using System;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.GrpcServices
{
    public class GrpcFlightsController : IGrpcFlightsController
    {
        private readonly IGrpcController _grpcController;
        private readonly Flights.FlightsClient flightsClient;

        public GrpcFlightsController(IGrpcController grpcController)
        {
            _grpcController = grpcController;
            flightsClient = grpcController.GetFlightsClient();
        }

        public IEnumerable<Flight> GetFlights()
        {
            var flights = new List<Flight>();

            var client = _grpcController.GetFlightsClient();

            var response = client.GetFlights(new Empty());

            foreach (var flight in response.Flight)
            {
                flights.Add(new Flight(flight.Origin, flight.Dest, flight.Carrier, flight.Tailnum, flight.Flight_, flight.Year, flight.Month, flight.Day, flight.DepTime, flight.DepDelay, flight.ArrTime, flight.ArrDelay, flight.AirTime, flight.Distance, flight.Hour, flight.Minute));
            }

            return flights;
        }

        public async Task<int> GetNumberOfFlightsAsync(int monthNumber)
        {
            var response = await flightsClient.GetNumberOfFlightsPerMonthAsync(new MonthNumber { Number = monthNumber });

            return response.Count;
        }
    }
}
