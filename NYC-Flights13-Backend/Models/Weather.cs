using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Models
{
    public class Weather
    {
        public string Origin { get; private set; }

        public int Year { get; private set; }

        public int Month { get; private set; }

        public int Day { get; private set; }
        
        public int Hour { get; private set; }

        public float Temperature { get; private set; }

        public float DewPoint { get; private set; }

        public float Humid { get; private set; }

        public int WindDirection { get; private set; }

        public float WindSpeed { get; private set; }

        public float WindGust { get; private set; }

        public float Precipitation { get; private set; }

        public float Pressure { get; private set; }

        public int Visiblity { get; private set; }

        public string TimeHour { get; private set; }




        public Weather(string origin, int year, int month, int day, int hour, float temp, float dewp, float humid, int wind_dir, float wind_speed, float wind_gust, float precip, float pressure, int visib, string time_hour )
        {
            Origin = origin;
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Temperature = temp;
            DewPoint = dewp;
            Humidity = humid;
            WindDirection = wind_dir;
            WindSpeed = wind_speed;
            WindGust = wind_gust;
            Precipitation = precip;
            Pressure = pressure;
            Visibility = visib;
            TimeHour = time_hour;


        }
    }
}
