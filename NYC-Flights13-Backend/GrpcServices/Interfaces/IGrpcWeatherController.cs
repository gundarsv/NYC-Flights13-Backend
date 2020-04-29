using System.Collections.Generic;
using NYC_Flights13_Backend.Models;

namespace NYC_Flights13_Backend.GrpcServices.Interfaces
{
    public interface IGrpcWeatherController
    {
        public IEnumerable<Weather> GetWeather();
    }
}
