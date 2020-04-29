using System.Collections.Generic;
using Airline = NYC_Flights13_Backend.Models.Airline;
using Plane = NYC_Flights13_Backend.Models.Plane;
using Empty = Google.Protobuf.WellKnownTypes.Empty;
using NYC_Flights13_Backend.GrpcServices.Interfaces;

namespace NYC_Flights13_Backend.GrpcServices
{
    public class GrpcPlanesController : IGrpcPlanesController
    {
        private readonly IGrpcController _grpcController;

        public GrpcPlanesController(IGrpcController grpcController)
        {
            _grpcController = grpcController;
        }

        public IEnumerable<Plane> GetPlanes()
        {
            var planes = new List<Plane>();

            var client = _grpcController.GetPlanesClient();

            var response = client.GetPlanes(new Empty());

            foreach (var plane in response.Planes)
            {
                planes.Add(new Plane(plane.Tailnum, plane.Year, plane.Type, plane.Manufacturer, plane.Model, plane.Engines, plane.Seats, plane.Speed, plane.Engine));
            }

            return planes;
        }
    }
}
