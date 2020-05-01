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

        [HttpGet, Route("numberOfFlightsPerMonth")]
        public IActionResult GetNumberOfFlightsPerMonthAsync()
        {
            int[] months = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var numberOfFlightsPerMonths = new List<FlightsPerMonth>();

            foreach (var month in months)
            {
                var numberOfFlightsRequest = _grpcFlightsController.GetNumberOfFlightsAsync(month).Result;
                numberOfFlightsPerMonths.Add(new FlightsPerMonth { Flights = numberOfFlightsRequest, Month = month });
            }

            return Ok(numberOfFlightsPerMonths);
        }
    }
}
