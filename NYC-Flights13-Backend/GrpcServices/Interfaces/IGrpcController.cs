using GrpcAirlines;
using GrpcPlanes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NYC_Flights13_Backend.GrpcServices.Interfaces
{
    public interface IGrpcController
    {
        public Airlines.AirlinesClient GetAirlinesClient();
        public Planes.PlanesClient GetPlanesClient();
    }


}
