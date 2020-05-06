using FlightDTO = NYC_Flights13_Backend.Models.FlightDTO;
using Empty = Google.Protobuf.WellKnownTypes.Empty;
using NYC_Flights13_Backend.GrpcServices.Interfaces;
using System.Collections.Generic;
using GrpcFlights;
using System;
using System.Threading.Tasks;
using AutoMapper;
using NYC_Flights13_Backend.Models;

namespace NYC_Flights13_Backend.GrpcServices
{
    public class GrpcFlightsController : IGrpcFlightsController
    {
        private readonly IGrpcController _grpcController;

        private readonly Flights.FlightsClient flightsClient;

        private readonly IMapper _mapper;

        public GrpcFlightsController(IGrpcController grpcController, IMapper mapper)
        {
            _mapper = mapper;
            _grpcController = grpcController;
            flightsClient = grpcController.GetFlightsClient();
        }

        public IEnumerable<FlightDTO> GetFlights()
        {
            var response = flightsClient.GetFlights(new Empty());

            var flights = _mapper.Map<List<FlightDTO>>(response.Flight);

            return flights;
        }

        public FlightsPerMonthDTO GetNumberOfFlights(int monthNumber)
        {
            var response = flightsClient.GetNumberOfFlightsPerMonth(new MonthNumber { Number = monthNumber });

            var flightsPerMonth = _mapper.Map<FlightsPerMonthDTO>(response);

            return flightsPerMonth;
        }

        public IEnumerable<FlightsPerMonthDTO> GetNumberOfFlightsInMonths(List<int> monthNumbers)
        {
            var allMonths = new AllMonths();

            var months = _mapper.Map<List<MonthNumber>>(monthNumbers);

            allMonths.MonthNumbers.AddRange(months);

            var response = flightsClient.GetNumberOfFlightsInMonths(allMonths);

            var flightsPerMonth = _mapper.Map<List<FlightsPerMonthDTO>>(response.FlightsPerMonth);

            return flightsPerMonth;
        }

        public IEnumerable<DestinationsForOriginDTO> GetTop10DestinationsForOrigin(string origin)
        {
            var response = flightsClient.GetTop10DestinationsForOrigin(new DestinationRequest { Origin = origin });

            var top10Destinations = _mapper.Map<List<DestinationsForOriginDTO>>(response.FlightsPerDestination);

            return top10Destinations;
        }
    }
}
