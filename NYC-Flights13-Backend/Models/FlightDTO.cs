using System;

namespace NYC_Flights13_Backend.Models
{
    public class FlightDTO
    {
        public string Origin { get; private set; }

        public string Destination { get; private set; }

        public string Carrier { get; private set; }

        public string TailNumber { get; private set; }

        public int FlightNumber { get; private set; }

        public DateTime Date { get; private set; }

        public int DepartureTime { get; private set; }

        public int DepartureDelay { get; private set; }

        public int ArrivalTime { get; private set; }

        public int ArrivalDelay { get; private set; }

        public int AirTime { get; private set; }

        public int Distance { get; private set; }

        public int Hour { get; private set; }

        public int Minute { get; private set; }

        public FlightDTO()
        {
        }

        public FlightDTO(string origin, string destination, string carrier, string tailNumber, int flightNumber, int year, int month, int day, int departureTime,
            int departureDelay, int arrivalTime, int arrivalDelay, int airTime, int distance,
            int hour, int minute)
        {
            Origin = origin;
            Destination = destination;
            Carrier = carrier;
            TailNumber = tailNumber;
            FlightNumber = flightNumber;
            Date = new DateTime(year, month, day);
            DepartureTime = departureTime;
            DepartureDelay = departureDelay;
            ArrivalTime = arrivalTime;
            ArrivalDelay = arrivalDelay;
            AirTime = airTime;
            Distance = distance;
            Hour = hour;
            Minute = minute;
        }
    }
}