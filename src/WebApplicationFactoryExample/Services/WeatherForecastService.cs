using WebApplicationFactoryExample.Model;

namespace WebApplicationFactoryExample.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public WeatherForecast Get()
        {
            return new WeatherForecast
            {
                Summary = nameof(WeatherForecast)
            };
        }
    }
}