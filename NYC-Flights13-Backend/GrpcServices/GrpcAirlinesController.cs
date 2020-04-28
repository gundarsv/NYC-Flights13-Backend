using System.Collections.Generic;
using Airline = NYC_Flights13_Backend.Models.Airline;
using Empty = Google.Protobuf.WellKnownTypes.Empty;
using NYC_Flights13_Backend.GrpcServices.Interfaces;

namespace NYC_Flights13_Backend.GrpcServices
{
    public class GrpcAirlinesController: IGrpcAirlinesController
    {
        private readonly IGrpcController _grpcController;

        public GrpcAirlinesController(IGrpcController grpcController)
        {
            _grpcController = grpcController;
        }

        public IEnumerable<Airline> GetAirlines()
        {
            var airlines = new List<Airline>();

            var client = _grpcController.GetAirlinesClient();
            
            var response = client.GetAirlines(new Empty());

            foreach (var airline in response.Airlines)
            {
                airlines.Add(new Airline(airline.Carrier, airline.Name));
            }

            return airlines;
        }
    }
}
