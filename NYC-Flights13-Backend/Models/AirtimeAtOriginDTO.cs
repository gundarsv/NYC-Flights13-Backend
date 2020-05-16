using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace NYC_Flights13_Backend.Models
{
    public class AirtimeAtOriginDTO
    {
        public float AirTime { get; set; }

        public string Origin { get; set; }


        public AirtimeAtOriginDTO()
        {
           
        }
    }
}
