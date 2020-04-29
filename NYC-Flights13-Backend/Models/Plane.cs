using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Models
{
    public class Plane
    {
        public string TailNumber { get; private set; }

        public int Year { get; private set; }

        public string Type { get; private set; }

        public string Manufacturer { get; private set; }

        public string Model { get; private set; }

        public int Engines { get; private set; }

        public int Seats { get; private set; }

        public int Speed { get; private set; }

        public string Engine { get; private set; }

        public Plane(string tailnumber, int year, string type, string manufacturer, string model, int engines, int seats, int speed, string engine )
        {
            TailNumber = tailnumber;
            Year = year;
            Type = type;
            Manufacturer = manufacturer;
            Model = model;
            Engines = engines;
            Seats = seats;
            Speed = speed;
            Engine = engine;
        }
    }
}
