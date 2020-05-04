using System.Collections.Generic;
using AirlineDTO = NYC_Flights13_Backend.Models.AirlineDTO;
using Empty = Google.Protobuf.WellKnownTypes.Empty;
using NYC_Flights13_Backend.GrpcServices.Interfaces;
using AutoMapper;
using GrpcAirlines;

namespace NYC_Flights13_Backend.GrpcServices
{
    public class GrpcAirlinesController: IGrpcAirlinesController
    {
        private readonly IGrpcController _grpcController;

        private readonly IMapper _mapper;

        private readonly Airlines.AirlinesClient airlinesClient;

        public GrpcAirlinesController(IGrpcController grpcController, IMapper mapper)
        {
            _mapper = mapper;
            _grpcController = grpcController;
            airlinesClient = grpcController.GetAirlinesClient();
        }

        public IEnumerable<AirlineDTO> GetAirlines()
        {
            var response = airlinesClient.GetAirlines(new Empty());

            var airlines = _mapper.Map<List<AirlineDTO>>(response.Airlines);

            return airlines;
        }
    }
}
