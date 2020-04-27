using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Models
{
    public class Airline
    {
        public string Carrier { get; private set; }

        public string Name { get; private set; }

        public Airline(string carrier, string name)
        {
            Carrier = carrier;
            Name = name;
        }
    }
}
