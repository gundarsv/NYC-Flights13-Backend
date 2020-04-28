using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using Grpc.Net.Client;
using GrpcAirlines;
using NYC_Flights13_Backend.GrpcServices.Interfaces;

namespace NYC_Flights13_Backend.GrpcServices
{
    public class GrpcController : IGrpcController
    {
        public GrpcChannel GrpcChannel { get; private set; }

        public Airlines.AirlinesClient AirlinesClient { get; private set; }

        public GrpcController()
        {
            var certLocation = Environment.GetEnvironmentVariable("CERTIFICATE_PATH");

            if (certLocation == null)
            {
                throw new Exception("Provide CERTIFICATE_PATH");
            }

            var certificate = new X509Certificate2(certLocation);

            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (request, cert, chain, errors) => certificate.Equals(cert)
            };

            var httpClient = new HttpClient(httpClientHandler);

            GrpcChannel = GrpcChannel.ForAddress("https://localhost:6001", new GrpcChannelOptions { HttpClient = httpClient });

            AirlinesClient = new Airlines.AirlinesClient(GrpcChannel);
        }

        public Airlines.AirlinesClient GetAirlinesClient()
        {
            return AirlinesClient;
        }
    }
}
