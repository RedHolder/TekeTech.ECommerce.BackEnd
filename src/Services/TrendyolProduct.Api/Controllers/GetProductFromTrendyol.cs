using Microsoft.AspNetCore.Mvc;

namespace TrendyolProduct.Api.Controllers
{
    public class GetProductFromTrendyol : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public GetProductFromTrendyol(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProductFromTrendyol")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
        }
    }
}
