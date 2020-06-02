using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NYC_Flights13_Backend.GrpcServices;
using NYC_Flights13_Backend.GrpcServices.Interfaces;
using NYC_Flights13_Backend.Models;

namespace NYC_Flights13_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanesController : ControllerBase
    {
        private readonly ILogger<PlanesController> _logger;

        private readonly IGrpcPlanesController _grpcPlanesController;

        public PlanesController(ILogger<PlanesController> logger, IGrpcPlanesController grpcPlanesController)
        {
            _logger = logger;
            _grpcPlanesController = grpcPlanesController;
        }

        [HttpGet, Route("")]
        public IActionResult GetAllPlanes()
        {
            var result = _grpcPlanesController.GetPlanes();

            return Ok(result);
        }

        [HttpGet, Route("manufacturers")]
        public IActionResult GetManufacturersWithMoreThan200Planes()
        {
            var result = _grpcPlanesController.GetManufacturersWithMoreThan200Planes();

            return Ok(result);
        }

        [HttpGet, Route("model")]
        public IActionResult GetNumberOfPlanesForEachManufacturerModel([FromQuery] string manufacturer)
       {
            var result = _grpcPlanesController.GetNumberOfPlanesForEachManufacturerModel(manufacturer);

            return Ok(result);
       }
    }
}