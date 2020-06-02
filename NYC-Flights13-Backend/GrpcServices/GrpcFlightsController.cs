using FlightDTO = NYC_Flights13_Backend.Models.FlightDTO;
using Empty = Google.Protobuf.WellKnownTypes.Empty;
using NYC_Flights13_Backend.GrpcServices.Interfaces;
using System.Collections.Generic;
using GrpcFlights;
using System;
using System.Threading.Tasks;
using AutoMapper;
using NYC_Flights13_Backend.Models;
using GrpcWeather;

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

        public IEnumerable<AirtimeAtOriginDTO> GetAirtimeAtOrigins(List <string> origins)
        {
            var allOrigins = new AirtimeRequests();

            var mappedOrigins = _mapper.Map<List<AirtimeRequest>>(origins);

            allOrigins.AllAirtimeRequests.AddRange(mappedOrigins);

            var response = flightsClient.GetAirtimeAtOrigins(allOrigins);

            var airtimeAtOrigin = _mapper.Map<List<AirtimeAtOriginDTO>>(response.AirtimeAtOrigins_);

            return airtimeAtOrigin;
        }

        public AirtimeAtOriginDTO GetAirtimeAtOrigin(string origin)
        {
            var response = flightsClient.GetAirtimeAtOrigin(new AirtimeRequest { Origin = origin});

            var airtimeAtOrigin = _mapper.Map<AirtimeAtOriginDTO>(response);

            return airtimeAtOrigin;
        }

        public IEnumerable<DestinationsForOriginDTO> GetTop10DestinationsForOrigin(string origin)
        {
            var response = flightsClient.GetTop10DestinationsForOrigin(new DestinationRequest { Origin = origin });

            var top10Destinations = _mapper.Map<List<DestinationsForOriginDTO>>(response.FlightsPerDestination);

            return top10Destinations;
        }

        public FlightsPerMonthOriginDTO GetNumberOfFlightsInMonthInOrigin(int monthNumber, string origin)
        {
            var response = flightsClient.GetNumberOfFlightsPerMonthInOrigin(new MonthOriginRequest { Month = monthNumber, Origin = origin });

            var flightsPerMonthInOrigin = _mapper.Map<FlightsPerMonthOriginDTO>(response);

            return flightsPerMonthInOrigin;
        }

        public IEnumerable<FlightsPerMonthOriginDTO> GetNumberOfFlightsInMonthInOrigins(int monthNumber, List<string> origins)
        {
            var monthOriginsRequest = new MonthOriginsRequest();

            monthOriginsRequest.Month = monthNumber;

            monthOriginsRequest.Origin.AddRange(origins);

            var response = flightsClient.GetNumberOfFlightsPerMonthInOrigins(monthOriginsRequest);

            var flightsPerMonthInOrigin = _mapper.Map<List<FlightsPerMonthOriginDTO>>(response.MonthsOrigins);

            return flightsPerMonthInOrigin;
        }

        public IEnumerable<FlightsPerMonthOriginDTO> GetNumberOfFlightsInMontshInOrigins(List<int> monthNumbers, List<string> origins)
        {
            var monthsOriginsRequest = new MonthsOriginsRequest();

            monthsOriginsRequest.Origin.AddRange(origins);

            monthsOriginsRequest.Month.AddRange(monthNumbers);

            var response = flightsClient.GetNumberOfFlightsInMonthsInOrigins(monthsOriginsRequest);

            var flightsPerMonthInOrigin = _mapper.Map<List<FlightsPerMonthOriginDTO>>(response.MonthsOrigins);

            return flightsPerMonthInOrigin;
        }

        public IEnumerable<FlightsPerMonthOriginDTO> GetNumberOfFlightsInMontshInOrigin(List<int> monthNumbers, string origin)
        {
            var monthsOriginRequest = new MonthsOriginRequest();

            monthsOriginRequest.Month.AddRange(monthNumbers);

            monthsOriginRequest.Origin = origin;

            var response = flightsClient.GetNumberOfFlightsInMonthsInOrigin(monthsOriginRequest);

            var flightsPerMonthInOrigin = _mapper.Map<List<FlightsPerMonthOriginDTO>>(response.MonthsOrigins);

            return flightsPerMonthInOrigin;
        }

        public IEnumerable<FlightsManufacturerDTO> GetNumberOfFlightsForManufacturers()
        {
            var response = flightsClient.GetNumberOfFlightsForManufacturersWithMoreThan200Planes(new Empty());

            var numberOfFlightsForManufactuer = _mapper.Map<List<FlightsManufacturerDTO>>(response.NumberOfFlightsManufacturer);

            return numberOfFlightsForManufactuer;
        }

        public IEnumerable<DepartureArrivalDelayAtOriginDTO> GetDepartureArrivalAtOrigins(List<string> origins)
        {
            var allOrigins = new OriginsRequest();

            var mappedOrigins = _mapper.Map<List<OriginRequest>>(origins);

            allOrigins.Origins.AddRange(mappedOrigins);

            var response = flightsClient.GetDepartureArrivalDelayAtOrigin(allOrigins);

            var departureArrivalDelays = _mapper.Map<List<DepartureArrivalDelayAtOriginDTO>>(response.DepartureArrivalDelay);

            return departureArrivalDelays;
        }
    }
}
