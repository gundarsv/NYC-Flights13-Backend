using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Models
{
    public class Flight
    {
        public int Id { get; private set; }

        public DateTime Date { get; private set; }

        public int DepartureTime { get; private set; }

        public int DepartureDelay { get; private set; }

        public int ArrivalTime { get; private set; }

        public int ArrivalDelay { get; private set; }

        public string Carrier { get; private set; }

        public string TailNumber { get; private set; }

        public string Origin { get; private set; }

        public string Destination { get; private set; }

        public int AirTime { get; private set; }

        public int Distance { get; private set; }

        public int Hour { get; private set; }

        public int Minute { get; private set; }


        public Flight(int id, int year, int month, int day, int departureTime, int departureDelay, int arrivalTime,
            int arrivalDelay, string carrier, string tailNumber, string origin, string destination, int airTime,
            int distance, int hour, int minute)
        {
            Id = id;
            Date = new DateTime(year,month,day);
            DepartureTime = departureTime;
            DepartureDelay = departureDelay;
            ArrivalTime = arrivalTime;
            ArrivalDelay = arrivalDelay;
            Carrier = carrier;
            TailNumber = tailNumber;
            Origin = origin;
            Destination = destination;
            AirTime = airTime;
            Distance = distance;
            Hour = hour;
            Minute = minute;
        }

    }

}
