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
        public async Task<IEnumerable<WeatherForecast>> GetAsync(string parameter)
        {
            var tasks = new List<Task>();

            ty = new TrendyolProduct();
            for (int i = 1; i < 2; i++)
            {
                tasks.Add(ty.GetReqAsync(parameter, i));
            }

            await Task.WhenAll(tasks);


            if (ty.trendyolProductModels.Count > 0)
            {
                return ty.trendyolProductModels.Select(item => new WeatherForecast
                {
                    FinalBrandName = item.FinalBrandName,
                    FinalProductName = item.FinalProductName,
                    FinalTerritoryName = item.FinalTerritoryName,
                    FinalPrice = item.FinalPrice,
                    FinalSizes = item.FinalSizes,
                    FinalStock = item.FinalStock,
                    FinalShippingTime = item.FinalShippingTime,
                    FinalFeatures = item.FinalFeatures,
                    ProductURL = item.ProductURL,
                    ProductChannel = item.ProductChannel
                });
            }
            else
            {
                // Handle the case where no data was retrieved, possibly returning an empty collection or an error message.
                // For now, let's return an empty collection:
                return Enumerable.Empty<WeatherForecast>();
            }
        }
    }
}