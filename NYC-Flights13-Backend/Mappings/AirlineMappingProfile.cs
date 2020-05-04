using AutoMapper;
using GrpcAirlines;
using NYC_Flights13_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Mappings
{
    public class AirlineMappingProfile : Profile
    {
        public AirlineMappingProfile()
        {
            CreateMap<Airline, AirlineDTO>()
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Name))
                .ForMember(x => x.Carrier, opt => opt.MapFrom(y => y.Carrier));
        }
    }
}
