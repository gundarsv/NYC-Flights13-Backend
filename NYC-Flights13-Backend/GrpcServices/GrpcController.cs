using System;
using Grpc.Net.Client;
using GrpcAirlines;
using NYC_Flights13_Backend.GrpcServices.Interfaces;
using GrpcPlanes;
using GrpcWeather;
using GrpcFlights;

namespace NYC_Flights13_Backend.GrpcServices
{
    public class GrpcController : IGrpcController
    {
        private readonly string GRPC_SERVER_PROTOCOL = Environment.GetEnvironmentVariable("GRPC_SERVER_PROTOCOL");

        private readonly string GRPC_SERVER_PORT = Environment.GetEnvironmentVariable("GRPC_SERVER_PORT");

        private readonly string GRPC_SERVER_HOST = Environment.GetEnvironmentVariable("GRPC_SERVER_HOST");

        private GrpcChannel GrpcChannel { get; set; }

        public Airlines.AirlinesClient AirlinesClient { get; private set; }

        public Planes.PlanesClient PlanesClient { get; private set; }

        public Weathers.WeathersClient WeathersClient { get; private set; }

        public Flights.FlightsClient FlightsClient { get; private set; }

        public GrpcController()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            GrpcChannel = GrpcChannel.ForAddress($"{GRPC_SERVER_PROTOCOL}://{GRPC_SERVER_HOST}:{GRPC_SERVER_PORT}", new GrpcChannelOptions
            {
                MaxReceiveMessageSize = 25 * 1024 * 1024, // ~26 MB
                MaxSendMessageSize = 25 * 1024 * 1024 // ~26 MB
            });

            AirlinesClient = new Airlines.AirlinesClient(GrpcChannel);

            PlanesClient = new Planes.PlanesClient(GrpcChannel);

            WeathersClient = new Weathers.WeathersClient(GrpcChannel);

            FlightsClient = new Flights.FlightsClient(GrpcChannel);
        }

        public Airlines.AirlinesClient GetAirlinesClient()
        {
            return AirlinesClient;
        }

        public Planes.PlanesClient GetPlanesClient()
        {
            return PlanesClient;
        }

        public Weathers.WeathersClient GetWeathersClient()
        {
            return WeathersClient;
        }

        public Flights.FlightsClient GetFlightsClient()
        {
            return FlightsClient;
        }
    }
}
