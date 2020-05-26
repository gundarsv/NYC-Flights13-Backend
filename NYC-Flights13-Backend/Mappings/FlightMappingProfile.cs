using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using GrpcFlights;
using NYC_Flights13_Backend.Models;
using GrpcWeather;

namespace NYC_Flights13_Backend.Mappings
{
    public class FlightMappingProfile : Profile
    {
        public FlightMappingProfile()
        {
            CreateMap<Flight, FlightDTO>()
                .ForMember(x => x.Origin, opt => opt.MapFrom(y => y.Origin))
                .ForMember(x => x.Destination, opt => opt.MapFrom(y => y.Dest))
                .ForMember(x => x.Carrier, opt => opt.MapFrom(y => y.Carrier))
                .ForMember(x => x.TailNumber, opt => opt.MapFrom(y => y.Tailnum))
                .ForMember(x => x.FlightNumber, opt => opt.MapFrom(y => y.Flight_))
                .ForMember(x => x.Date, opt => opt.MapFrom(y => new DateTime(y.Year, y.Month, y.Day)))
                .ForMember(x => x.DepartureTime, opt => opt.MapFrom(y => y.DepTime))
                .ForMember(x => x.DepartureDelay, opt => opt.MapFrom(y => y.DepDelay))
                .ForMember(x => x.ArrivalTime, opt => opt.MapFrom(y => y.ArrTime))
                .ForMember(x => x.ArrivalDelay, opt => opt.MapFrom(y => y.ArrDelay))
                .ForMember(x => x.AirTime, opt => opt.MapFrom(y => y.AirTime))
                .ForMember(x => x.Distance, opt => opt.MapFrom(y => y.Distance))
                .ForMember(x => x.Hour, opt => opt.MapFrom(y => y.Hour))
                .ForMember(x => x.Minute, opt => opt.MapFrom(y => y.Minute));

            CreateMap<FlightsPerMonth, FlightsPerMonthDTO>()
                .ForMember(x => x.Flights, opt => opt.MapFrom(y => y.FlightsCount))
                .ForMember(x => x.Month, opt => opt.MapFrom(y => y.MonthNumber.Number));

            CreateMap<int, MonthNumber>()
                .ForMember(x => x.Number, opt => opt.MapFrom(y => y));

            CreateMap<FlightsPerDestination, DestinationsForOriginDTO>()
                .ForMember(x => x.NumberOfFlights, opt => opt.MapFrom(y => y.NumberOfFlights))
                .ForMember(x => x.Destination, opt => opt.MapFrom(y => y.Destination))
                .ForMember(x => x.Origin, opt => opt.MapFrom(y => y.Origin));

            CreateMap<AirtimeAtOrigin, AirtimeAtOriginDTO>()
                .ForMember(x => x.AirTime, opt => opt.MapFrom(y => y.AirTime))
                .ForMember(x => x.Origin, opt => opt.MapFrom(y => y.Origin));

            CreateMap<string, AirtimeRequest>()
                .ForMember(x => x.Origin, opt => opt.MapFrom(y => y));

            CreateMap<MonthOriginResponse, FlightsPerMonthOriginDTO>()
                .ForMember(x => x.Flights, opt => opt.MapFrom(y => y.Flights))
                .ForMember(x => x.Month, opt => opt.MapFrom(y => y.Month))
                .ForMember(x => x.Origin, opt => opt.MapFrom(y => y.Origin));

            CreateMap<NumberOfFlightsManufacturer, FlightsManufacturerDTO>()
               .ForMember(x => x.NumberOfFlights, opt => opt.MapFrom(y => y.NumberOfFlights))
               .ForMember(x => x.Manufacturer, opt => opt.MapFrom(y => y.Manufacturer));
        }
    }
}
