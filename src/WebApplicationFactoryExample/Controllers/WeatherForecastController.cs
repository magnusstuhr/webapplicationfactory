using System;
using Microsoft.AspNetCore.Mvc;
using WebApplicationFactoryExample.Model;
using WebApplicationFactoryExample.Services;

namespace WebApplicationFactoryExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            WeatherForecast weatherForecast;
            try
            {
                weatherForecast = _weatherForecastService.Get();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok(weatherForecast);
        }
    }
}