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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            ty = new TrendyolProduct();
            ty.getreq("");
           

         
            return Enumerable.Range(1, 20).Select(index => new WeatherForecast
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