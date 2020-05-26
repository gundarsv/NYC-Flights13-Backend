using PlaneDTO = NYC_Flights13_Backend.Models.PlaneDTO;
using Empty = Google.Protobuf.WellKnownTypes.Empty;
using NYC_Flights13_Backend.GrpcServices.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using GrpcPlanes;
using NYC_Flights13_Backend.Models;

namespace NYC_Flights13_Backend.GrpcServices
{
    public class GrpcPlanesController : IGrpcPlanesController
    {
        private readonly IGrpcController _grpcController;

        private readonly IMapper _mapper;

        private readonly Planes.PlanesClient planesClient;

        public GrpcPlanesController(IGrpcController grpcController, IMapper mapper)
        {
            _mapper = mapper;
            _grpcController = grpcController;
            planesClient = grpcController.GetPlanesClient();
        }

        public IEnumerable<PlaneDTO> GetPlanes()
        {
            var response = planesClient.GetPlanes(new Empty());

            var planes = _mapper.Map<List<PlaneDTO>>(response.Planes);

            return planes;
        }

        public IEnumerable<ManufacturerDTO> GetManufacturersWithMoreThan200Planes()
        {
            var response = planesClient.GetManufacturersWithMoreThan200Planes(new Empty());

            var manufacturersWithMoreThan200Planes = _mapper.Map<List<ManufacturerDTO>>(response.Manufacturers);

            return manufacturersWithMoreThan200Planes;
        }

        public IEnumerable<NumberOfPlanesForEachManufacturerModelDTO> GetNumberOfPlanesForEachManufacturerModel(string manufacturer)
        {
            var response = planesClient.GetNumberOfPlanesForEachManufacturerModel(new Manufacturer { Manufacturer_ = manufacturer });

            var numberOfPlanesForEachManufacturerModel = _mapper.Map<List<NumberOfPlanesForEachManufacturerModelDTO>>(response.NumberOfPlanesForModel);

            return numberOfPlanesForEachManufacturerModel;
        }
    }
}
