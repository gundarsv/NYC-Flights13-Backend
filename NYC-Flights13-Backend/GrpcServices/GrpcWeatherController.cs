using WeatherDTO = NYC_Flights13_Backend.Models.WeatherDTO;
using Empty = Google.Protobuf.WellKnownTypes.Empty;
using NYC_Flights13_Backend.GrpcServices.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using GrpcWeather;
using NYC_Flights13_Backend.Models;

namespace NYC_Flights13_Backend.GrpcServices
{
    public class GrpcWeatherController : IGrpcWeatherController
    {
        private readonly IGrpcController _grpcController;

        private readonly Weathers.WeathersClient weathersClient;

        private readonly IMapper _mapper;

        public GrpcWeatherController(IGrpcController grpcController, IMapper mapper)
        {
            _mapper = mapper;
            _grpcController = grpcController;
            weathersClient = grpcController.GetWeathersClient();
        }

        public IEnumerable<DailyMeanTemperatureAtOriginDTO> GetDailyMeanTemperatureAtOrigin(string origin)
        {
            var response = weathersClient.GetDailyMeanTemperatureAtOrigin(new OriginRequest { Origin = origin });

            var dailyMeanTemperatureAtOrigin = _mapper.Map<List<DailyMeanTemperatureAtOriginDTO>>(response.DailyMeanTemperatures);

            return dailyMeanTemperatureAtOrigin;
        }

        public ObservationsAtOriginDTO GetObservationsAtOrigin(string origin)
        {
            var response = weathersClient.GetWeatherObservationsAtOrigin(new OriginRequest { Origin = origin });

            var observationsAtOrigin = _mapper.Map<ObservationsAtOriginDTO>(response);

            return observationsAtOrigin;
        }

        public IEnumerable<ObservationsAtOriginDTO> GetObservationsAtOrigins(List<string> origins)
        {
            var allOrigins = new OriginsRequest();

            var mappedOrigins = _mapper.Map<List<OriginRequest>>(origins);

            allOrigins.Origins.AddRange(mappedOrigins);

            var response = weathersClient.GetWeatherObservationsAtOrigins(allOrigins);

            var observationsAtOrigins = _mapper.Map<List<ObservationsAtOriginDTO>>(response.Observations);

            return observationsAtOrigins;
        }

        public IEnumerable<TemperatureAtOriginDTO> GetTemperatureAtOrigin(string origin)
        {
            var response = weathersClient.GetTemperatureAtOrigin(new OriginRequest { Origin = origin });

            var temperatureAtOrigin = _mapper.Map<List<TemperatureAtOriginDTO>>(response.TemperatureAtOrigins);

            return temperatureAtOrigin;
        }

        public IEnumerable<TemperatureAtOriginWithOriginDTO> GetTemperatureAtOrigins(List<string> origins)
        {
            var allOrigins = new OriginsRequest();

            var mappedOrigins = _mapper.Map<List<OriginRequest>>(origins);

            allOrigins.Origins.AddRange(mappedOrigins);

            var response = weathersClient.GetTemperatureAtOrigins(allOrigins);

            var temperatureAtOrigins = _mapper.Map<List<TemperatureAtOriginWithOriginDTO>>(response.AllOriginTemperatures);

            return temperatureAtOrigins;
        }

        public IEnumerable<WeatherDTO> GetWeather()
        {
            var response = weathersClient.GetWeather(new Empty());

            var weathers = _mapper.Map<List<WeatherDTO>>(response.Weather);

            return weathers;
        }
    }
}
