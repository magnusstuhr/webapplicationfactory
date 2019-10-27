using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using WebApplicationFactoryExample;
using WebApplicationFactoryExample.Model;
using Xunit;

namespace WebApplicationFactoryExampleTests
{
    public class WeatherForecastControllerIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private const string WeatherForecastUriPath = "weatherforecast";

        private static HttpClient _httpClientWithFullIntegration;

        private readonly WebApplicationFactory<Startup> _webApplicationFactory;

        public WeatherForecastControllerIntegrationTests(WebApplicationFactory<Startup> webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
            _httpClientWithFullIntegration ??= webApplicationFactory.CreateClient();
        }

        [Fact]
        public async void Get_WithFullyIntegratedServices_ReturnsOkWithExpectedResponse()
        {
            // Act
            var weatherForecastResponse = await _httpClientWithFullIntegration.GetAsync(WeatherForecastUriPath);

            // Assert
            Assert.Equal(HttpStatusCode.OK, weatherForecastResponse.StatusCode);

            var weatherForecastContent = await weatherForecastResponse.Content.ReadAsStringAsync();
            var weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(weatherForecastContent);

            Assert.NotNull(weatherForecast);
            Assert.NotNull(weatherForecast.Summary);
        }
    }
}