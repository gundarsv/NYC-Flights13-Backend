using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NYC_Flights13_Backend.GrpcServices;
using NYC_Flights13_Backend.Models;

namespace NYC_Flights13_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirlinesController : ControllerBase
    {
        private readonly ILogger<AirlinesController> _logger;
        private readonly IGrpcAirlinesController _grpcAirlinesController;


        public AirlinesController(ILogger<AirlinesController> logger, IGrpcAirlinesController grpcAirlinesController)
        {
            _logger = logger;
            _grpcAirlinesController = grpcAirlinesController;
        }

        [HttpGet, Route("")]
        public IActionResult GetAllAirlines()
        {
            var result = _grpcAirlinesController.GetAirlines();

            return Ok(result);
        }
    }
}