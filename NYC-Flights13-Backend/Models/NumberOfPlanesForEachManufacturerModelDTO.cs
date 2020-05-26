using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Models
{
    public class NumberOfPlanesForEachManufacturerModelDTO
    {
        public string Model { get; set; }

        public int NumberOfPlanes { get; set; }

        public string Manufacturer { get; set; }

        public NumberOfPlanesForEachManufacturerModelDTO()
        {

        }
    }
}
