using AutoMapper;
using GrpcWeather;
using NYC_Flights13_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Mappings
{
    public class WeatherMappingProfile : Profile
    {
        public WeatherMappingProfile()
        {
            CreateMap<Weather, WeatherDTO>()
                .ForMember(x => x.Origin, opt => opt.MapFrom(y => y.Origin))
                .ForMember(x => x.Year, opt => opt.MapFrom(y => y.Year))
                .ForMember(x => x.Month, opt => opt.MapFrom(y => y.Month))
                .ForMember(x => x.Day, opt => opt.MapFrom(y => y.Day))
                .ForMember(x => x.Hour, opt => opt.MapFrom(y => y.Hour))
                .ForMember(x => x.Temperature, opt => opt.MapFrom(y => y.Temp))
                .ForMember(x => x.DewPoint, opt => opt.MapFrom(y => y.Dewp))
                .ForMember(x => x.Humidity, opt => opt.MapFrom(y => y.Humid))
                .ForMember(x => x.WindDirection, opt => opt.MapFrom(y => y.WindDir))
                .ForMember(x => x.WindSpeed, opt => opt.MapFrom(y => y.WindSpeed))
                .ForMember(x => x.WindGust, opt => opt.MapFrom(y => y.WindGust))
                .ForMember(x => x.Precipitation, opt => opt.MapFrom(y => y.Precip))
                .ForMember(x => x.Pressure, opt => opt.MapFrom(y => y.Pressure))
                .ForMember(x => x.Visiblity, opt => opt.MapFrom(y => y.Visib))
                .ForMember(x => x.TimeHour, opt => opt.MapFrom(y => y.TimeHour));
        }
    }
}
