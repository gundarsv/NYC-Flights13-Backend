using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NYC_Flights13_Backend.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcAirlines;
using Airline = NYC_Flights13_Backend.Models.Airline;
using Empty = Google.Protobuf.WellKnownTypes.Empty;
using System.Security.Cryptography.X509Certificates;

namespace NYC_Flights13_Backend.GrpcServices
{
    public class GrpcAirlinesController: IGrpcAirlinesController
    {
        public IEnumerable<Airline> GetAirlines()
        {
            
            var certLocation = Environment.GetEnvironmentVariable("CERTIFICATE_PATH");

            var certificate = new X509Certificate2(certLocation);

            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (request, cert, chain, errors) => certificate.Equals(cert)
            };

            var httpClient = new HttpClient(httpClientHandler);

            var channel = GrpcChannel.ForAddress("https://localhost:6001", new GrpcChannelOptions { HttpClient = httpClient });
            var airlines = new List<Airline>();

            var client = new Airlines.AirlinesClient(channel);
            
            var response = client.GetAirlines(new Empty());

            foreach (var airline in response.Airlines)
            {
                airlines.Add(new Airline(airline.Carrier, airline.Name));
            }

            return airlines;
        }
    }
}
