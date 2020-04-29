using Weather = NYC_Flights13_Backend.Models.Weather;
using Empty = Google.Protobuf.WellKnownTypes.Empty;
using NYC_Flights13_Backend.GrpcServices.Interfaces;
using System.Collections.Generic;

namespace NYC_Flights13_Backend.GrpcServices
{
    public class GrpcWeatherController : IGrpcWeatherController
    {
        private readonly IGrpcController _grpcController;

        public GrpcWeatherController(IGrpcController grpcController)
        {
            _grpcController = grpcController;
        }

        public IEnumerable<Weather> GetWeather()
        {
            var weathers = new List<Weather>();

            var client = _grpcController.GetWeathersClient();

            var response = client.GetWeather(new Empty());

            foreach (var weather in response.Weather)
            {
                weathers.Add(new Weather(weather.Origin, weather.Year, weather.Month, weather.Day, weather.Hour, weather.Temp, weather.Dewp, weather.Humid, weather.WindDir, weather.WindSpeed, weather.WindGust, weather.Precip, weather.Pressure, weather.Visib, weather.TimeHour ));
            }

            return weathers;
        }
    }
}
