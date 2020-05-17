using System.Collections.Generic;
using NYC_Flights13_Backend.Models;

namespace NYC_Flights13_Backend.GrpcServices.Interfaces
{
    public interface IGrpcWeatherController
    {
        public IEnumerable<WeatherDTO> GetWeather();

        public IEnumerable<TemperatureAtOriginDTO> GetTemperatureAtOrigin(string origin);

        public ObservationsAtOriginDTO GetObservationsAtOrigin(string origin);

        public IEnumerable<TemperatureAtOriginWithOriginDTO> GetTemperatureAtOrigins(List<string> origins);

        public IEnumerable<ObservationsAtOriginDTO> GetObservationsAtOrigins(List<string> origins);

        public IEnumerable<DailyMeanTemperatureAtOriginDTO> GetDailyMeanTemperatureAtOrigin(string origin);

        public IEnumerable<DailyMeanTemperatureAtOriginDTO> GetDailyMeanTemperatureAtOrigins(List<string> origins);
    }
}
