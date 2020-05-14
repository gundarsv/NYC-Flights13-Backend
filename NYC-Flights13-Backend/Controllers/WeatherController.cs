﻿using System;
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
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IGrpcWeatherController _grpcWeatherController;

        public WeatherController(ILogger<WeatherController> logger, IGrpcWeatherController grpcWeatherController)
        {
            _logger = logger;
            _grpcWeatherController = grpcWeatherController;
        }

        [HttpGet, Route("")]
        public IActionResult GetAllWeather()
        {
            var result = _grpcWeatherController.GetWeather();

            return Ok(result);
        }

        [HttpGet, Route("temperature")]
        public IActionResult GetTemperatureAtOrigin([FromQuery] string origin)
        {
            var result = _grpcWeatherController.GetTemperatureAtOrigin(origin);

            return Ok(result);
        }

        [HttpGet, Route("observations")]
        public IActionResult GetObservationsAtOrigin([FromQuery] string origin)
        {
            var result = _grpcWeatherController.GetObservationsAtOrigin(origin);

            return Ok(result);
        }

        [HttpGet, Route("temperature/origins")]
        public IActionResult GetTemperatureAtOrigins()
        {
            var origins = new List<string>() {"JFK", "EWR", "LGA"};

            var result = _grpcWeatherController.GetTemperatureAtOrigins(origins);

            return Ok(result);
        }
    }
}