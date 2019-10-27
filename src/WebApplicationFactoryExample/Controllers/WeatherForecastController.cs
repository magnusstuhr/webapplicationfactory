using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationFactoryExample.Model;
using WebApplicationFactoryExample.Services;

namespace WebApplicationFactoryExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherForecastService weatherForecastService,
            ILogger<WeatherForecastController> logger)
        {
            _weatherForecastService = weatherForecastService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new NotImplementedException();
        }
    }
}