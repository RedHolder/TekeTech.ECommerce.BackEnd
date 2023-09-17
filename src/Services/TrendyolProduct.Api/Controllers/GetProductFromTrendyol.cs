using Microsoft.AspNetCore.Mvc;

namespace TrendyolProduct.Api.Controllers
{
    public class GetProductFromTrendyol : Controller
    {
        private GetProductListFromCategory GetCatalog;
        private List<String>? CatalogURLList;

        private readonly ILogger<WeatherForecastController> _logger;

        public GetProductFromTrendyol(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{parameter}", Name = "GetProductFromTrendyol")]
        public IEnumerable<WeatherForecast> Get(string parameter)
        {
            
            GetCatalog = new GetProductListFromCategory();
            CatalogURLList = GetCatalog.SendRequest(1, parameter);
            return Enumerable.Range(1, 20).Select(index => new WeatherForecast
            {
               Summary = CatalogURLList[index],
            })
            .ToArray();
        }
    }
}
