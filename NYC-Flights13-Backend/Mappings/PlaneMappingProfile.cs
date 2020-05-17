using AutoMapper;
using GrpcPlanes;
using NYC_Flights13_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Mappings
{
    public class PlaneMappingProfile : Profile
    {
        public PlaneMappingProfile()
        {
            CreateMap<Plane, PlaneDTO>()
                .ForMember(x => x.TailNumber, opt => opt.MapFrom(y => y.Tailnum))
                .ForMember(x => x.Year, opt => opt.MapFrom(y => y.Year))
                .ForMember(x => x.Type, opt => opt.MapFrom(y => y.Type))
                .ForMember(x => x.Manufacturer, opt => opt.MapFrom(y => y.Manufacturer))
                .ForMember(x => x.Model, opt => opt.MapFrom(y => y.Model))
                .ForMember(x => x.Engines, opt => opt.MapFrom(y => y.Engines))
                .ForMember(x => x.Seats, opt => opt.MapFrom(y => y.Seats))
                .ForMember(x => x.Speed, opt => opt.MapFrom(y => y.Speed))
                .ForMember(x => x.Engine, opt => opt.MapFrom(y => y.Engine));

            CreateMap<Manufacturer, ManufacturerDTO>()
                .ForMember(x => x.Planes, opt => opt.MapFrom(y => y.Planes))
                .ForMember(x => x.Manufacturer, opt => opt.MapFrom(y => y.Manufacturer_));
        }
    }
}
