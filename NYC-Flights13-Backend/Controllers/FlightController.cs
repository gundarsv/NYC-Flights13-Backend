using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NYC_Flights13_Backend.GrpcServices.Interfaces;
using NYC_Flights13_Backend.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NYC_Flights13_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly ILogger<FlightsController> _logger;

        private readonly IGrpcFlightsController _grpcFlightsController;

        private readonly List<int> _months = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        private readonly List<string> _origins = new List<string>() { "JFK", "EWR", "LGA" };

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
            var result = _grpcFlightsController.GetNumberOfFlightsInMonths(_months);

            return Ok(result);
        }

        [HttpGet, Route("airtime/mean/origins")]
        public IActionResult GetAirtimeAtOrigins()
        {
            var result = _grpcFlightsController.GetAirtimeAtOrigins(_origins);

            return Ok(result);
        }

        [HttpGet, Route("airtime/mean")]
        public IActionResult GetAirtimeAtOrigin([FromQuery] string origin)
        {
            var result = _grpcFlightsController.GetAirtimeAtOrigin(origin);

            return Ok(result);
        }

        [HttpGet, Route("destinations")]
        public IActionResult GetTop10DestinationsForOrigin([FromQuery] string origin)
        {
            var result = _grpcFlightsController.GetTop10DestinationsForOrigin(origin);

            return Ok(result);
        }

        [HttpGet, Route("month/{month}/origin/{origin}")]
        public IActionResult GetNumberOfFlightsInMonthInOrigin(int month, string origin)
        {
            var result = _grpcFlightsController.GetNumberOfFlightsInMonthInOrigin(month, origin);

            return Ok(result);
        }

        [HttpGet, Route("month/{month}/origin/origins")]
        public IActionResult GetNumberOfFlightsInMonthInOrigins(int month)
        {
            var result = _grpcFlightsController.GetNumberOfFlightsInMonthInOrigins(month, _origins);

            return Ok(result);
        }

        [HttpGet, Route("month/months/origin/{origin}")]
        public IActionResult GetNumberOfFlightsInMontshInOrigin(string origin)
        {
            var result = _grpcFlightsController.GetNumberOfFlightsInMontshInOrigin(_months, origin);

            return Ok(result);
        }

        [HttpGet, Route("month/months/origin/origins")]
        public IActionResult GetNumberOfFlightsInMontshInOrigins([FromQuery] bool percentage = false)
        {
            var result = _grpcFlightsController.GetNumberOfFlightsInMontshInOrigins(_months, _origins);

            if (percentage)
            {
                return Ok(GetPercentage(result));
            }

            return Ok(result);
        }

        [HttpGet, Route("manufacturers")]
        public IActionResult GetNumberOfFlightsForManufacturers()
        {
            var result = _grpcFlightsController.GetNumberOfFlightsForManufacturers();

            return Ok(result);
        }

        [HttpGet, Route("delays/origins")]
        public IActionResult GetDepartureArrivalDelaysForOrigin()
        {
            var result = _grpcFlightsController.GetDepartureArrivalAtOrigins(_origins);

            return Ok(result);
        }

        private IList GetPercentage(IEnumerable<FlightsPerMonthOriginDTO> flightsPerMonthOriginDTOs)
        {
            return flightsPerMonthOriginDTOs
                .GroupBy(x => x.Month)
                .Join(
                        flightsPerMonthOriginDTOs.GroupBy(y => new { y.Month, y.Origin }),
                        x => x.Key,
                        y => y.Key.Month,
                        (a, b) => new { Month = a.Key, b.Key.Origin, Percentage = b.Sum(x => x.Flights) / (double)a.Sum(x => x.Flights) }
                    ).ToList();
        }
    }
}