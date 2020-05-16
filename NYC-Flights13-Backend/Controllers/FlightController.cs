using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NYC_Flights13_Backend.GrpcServices.Interfaces;
using NYC_Flights13_Backend.Models;

namespace NYC_Flights13_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly ILogger<FlightsController> _logger;

        private readonly IGrpcFlightsController _grpcFlightsController;

        public FlightsController(ILogger<FlightsController> logger, IGrpcFlightsController grpcFlightsController)
        {
            _logger = logger;
            _grpcFlightsController = grpcFlightsController;
        }

        [HttpGet, Route("")]
        public IActionResult GetAllFlights()
        {
            var result = _grpcFlightsController.GetFlights();

            return Ok(result);
        }

        [HttpGet, Route("month")]
        public IActionResult GetNumberOfFlightsPerMonth([FromQuery] int month)
        {
           var result = _grpcFlightsController.GetNumberOfFlights(month);

            return Ok(result);
        }

        [HttpGet, Route("months")]
        public IActionResult GetNumberOfFlightsInMonths()
        {
            var months = new List<int> { 1, 2, 3, 4, 5 , 6, 7, 8, 9, 10, 11, 12};

            var result = _grpcFlightsController.GetNumberOfFlightsInMonths(months);

            return Ok(result);
        }

        [HttpGet, Route("airtime/mean/origins")]
        public IActionResult GetAirtimeAtOrigins()
        {
            var origins = new List<string>() { "JFK", "EWR", "LGA" };

            var result = _grpcFlightsController.GetAirtimeAtOrigins(origins);

            return Ok(result);
        }

        [HttpGet, Route("airtime/mean")]
        public IActionResult GetAirtimeAtOrigin([FromQuery] string origin)
        {
            var result = _grpcFlightsController.GetAirtimeAtOrigin(origin);

            return Ok(result);
        }

        [HttpGet, Route("destinations")]
        public IActionResult GetTop10DestinationsForOrigin([FromQuery ]string origin)
        {
            var result = _grpcFlightsController.GetTop10DestinationsForOrigin(origin);

            return Ok(result);
        }
    }
}
