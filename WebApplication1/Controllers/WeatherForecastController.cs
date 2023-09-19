using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly DashboardContext _dashboardContext;

        public WeatherForecastController(DashboardContext dashboardContext)
        {
          _dashboardContext = dashboardContext;
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

            foreach (TrendyolProductModel typ in ty.trendyolProductModels)
            {
                var ent = new ProductModel_Trendyol
                {
                    Id = Guid.NewGuid().ToString(),
                    FinalBrandName = typ.FinalBrandName,
                    FinalFeatures = typ.FinalFeatures,
                    FinalPrice = typ.FinalPrice,
                    FinalProductName = typ.FinalProductName,
                    FinalShippingTime = typ.FinalShippingTime,
                    FinalSizes = typ.FinalSizes,
                    FinalStock = typ.FinalStock,
                    FinalTerritoryName = typ.FinalTerritoryName,
                    ProductChannel = typ.ProductChannel,
                    ProductURL = typ.ProductURL
                };

                _dashboardContext.TrendyolProductModel.Add(ent);
            }
            _dashboardContext.SaveChanges();

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