using WeatherDTO = NYC_Flights13_Backend.Models.WeatherDTO;
using Empty = Google.Protobuf.WellKnownTypes.Empty;
using NYC_Flights13_Backend.GrpcServices.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using GrpcWeather;

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

        public IEnumerable<WeatherDTO> GetWeather()
        {
            var response = weathersClient.GetWeather(new Empty());

            var weathers = _mapper.Map<List<WeatherDTO>>(response.Weather);

            return weathers;
        }
    }
}
