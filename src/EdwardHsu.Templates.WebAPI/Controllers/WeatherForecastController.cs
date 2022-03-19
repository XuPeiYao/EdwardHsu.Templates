using System.ComponentModel;
using System.Net;
using EdwardHsu.Templates.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdwardHsu.Templates.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Description("Get weather list")]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), (int)HttpStatusCode.OK)]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(
                                 index => new WeatherForecast
                                 {
                                     Date         = DateTime.Now.AddDays(index),
                                     TemperatureC = Random.Shared.Next(-20, 55),
                                     Summary      = Summaries[Random.Shared.Next(Summaries.Length)]
                                 })
                             .ToArray();
        }
    }
}
