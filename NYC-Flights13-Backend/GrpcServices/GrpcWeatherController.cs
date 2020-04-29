using System.Collections.Generic;
using Airline = NYC_Flights13_Backend.Models.Airline;
using Plane = NYC_Flights13_Backend.Models.Plane;
using Weather = NYC_Flights13_Backend.Models.Weather;
using Empty = Google.Protobuf.WellKnownTypes.Empty;
using NYC_Flights13_Backend.GrpcServices.Interfaces;

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
            var weather = new List<Weather>();

            var client = _grpcController.GetWeatherClient();

            var response = client.GetWeather(new Empty());

            foreach (var weather in response.Weather)
            {
                Weather.Add(new Weather(weather.Origin, weather.Year, weather.Month, weather.Day, weather.Hour, weather.Temp, weather.Dewp, weather.Humid, weather.Wind_dir, weather.Wind_speed, weather.Wind_gust, weather.Precip, weather.Pressure, weather.Visib, weather.Time_hour ));
            }

            return weather;
        }
    }
}
