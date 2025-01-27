﻿using AutoMapper;
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
                .ForMember(x => x.TimeHour, opt => opt.MapFrom(y => y.TimeHour))
                .ForMember(x => x.TemperatureInCelsius, opt => opt.MapFrom(y => (y.Temp - 32) * 5/9));

            CreateMap<TemperatureAtOrigin, TemperatureAtOriginDTO>()
                .ForMember(x => x.TemperatureInFahrenheit, opt => opt.MapFrom(y => y.Temp))
                .ForMember(x => x.TemperatureInCelsius, opt => opt.MapFrom(y => (y.Temp - 32) * 5 / 9))
                .ForMember(x => x.DateTime, opt => opt.MapFrom(y => new DateTime(y.Year, y.Month, y.Day, y.Hour, 0, 0)))
                .ForMember(x => x.Origin, opt => opt.MapFrom(y => y.Origin));
                

            CreateMap<ObservationResponse, ObservationsAtOriginDTO>()
                .ForMember(x => x.Observations, opt => opt.MapFrom(y => y.ObservationsAtOrigin))
                .ForMember(x => x.Origin, opt => opt.MapFrom(y => y.Origin));

            CreateMap<AllOriginTemperature, TemperatureAtOriginWithOriginDTO>()
                .ForMember(x => x.TemperatureInFahrenheit, opt => opt.MapFrom(y => y.TemperatureAtOrigin.Temp))
                .ForMember(x => x.TemperatureInCelsius, opt => opt.MapFrom(y => (y.TemperatureAtOrigin.Temp - 32) * 5 / 9))
                .ForMember(x => x.DateTime, opt => opt.MapFrom(y => new DateTime(y.TemperatureAtOrigin.Year, y.TemperatureAtOrigin.Month, y.TemperatureAtOrigin.Day, y.TemperatureAtOrigin.Hour, 0, 0)))
                .ForMember(x => x.Origin, opt => opt.MapFrom(y => y.Origin));

            CreateMap<string, OriginRequest>()
                .ForMember(x => x.Origin, opt => opt.MapFrom(y => y));

            CreateMap<DailyMeanTemperature, DailyMeanTemperatureAtOriginDTO>()
                .ForMember(x => x.DailyMeanTemperatureInFahrenheit, opt => opt.MapFrom(y => y.MeanTemp))
                .ForMember(x => x.DailyMeanTemperatureInCelsius, opt => opt.MapFrom(y => (y.MeanTemp - 32) * 5 / 9))
                .ForMember(x => x.DateTime, opt => opt.MapFrom(y => new DateTime(y.Year, y.Month, y.Day)))
                .ForMember(x => x.Origin, opt => opt.MapFrom(y => y.Origin));
        }
    }
}
