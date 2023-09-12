using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
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

        TrendyolProduct ty;

        [HttpGet("{parameter}", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(string parameter)
        {
            ty = new TrendyolProduct();
            ty.getreq(parameter);
           

         
            return Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                BrandName = ty.trendyolProductModels[index].FinalBrandName,
                ProductName = ty.trendyolProductModels[index].FinalProductName,
                TerritoryName = ty.trendyolProductModels[index].FinalTerritoryName,
                Price = ty.trendyolProductModels[index].FinalPrice,
                Sizes = ty.trendyolProductModels[index].FinalSizes,
                Stock = ty.trendyolProductModels[index].FinalStock,
                ProductURL = ty.trendyolProductModels[index].ProductURL,
                ProductChannel = ty.trendyolProductModels[index].ProductChannel
            })
            .ToArray();
        }
    }
}