using Microsoft.AspNetCore.Mvc;
using TrendyolProduct.Api.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using log4net;
using System.Text;

namespace TrendyolProduct.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductTrendyolController : Controller
    {
        private GetProductListFromCategory GetCatalog;
        private List<ProductURL>? CatalogURLList;

        private readonly TyContext _dashboardContext;
        private readonly ILog _log;

        public ProductTrendyolController(TyContext dashboardContext)
        {
           // _log = LogManager.GetLogger(typeof(ProductTrendyolController));
            _dashboardContext = dashboardContext;
        }

        [HttpGet("{parameter}", Name = "GetProductTrendyol")]
        public IEnumerable<ProductURL> Get(string parameter)
        {

            GetCatalog = new GetProductListFromCategory();
            var existingCatalogs = _dashboardContext.ProductURL.Select(p => p.TrendyolProductURL).ToList();

            

                for (int i = 1; i < 500; i++)
                {
                    try
                    {
                    CatalogURLList = GetCatalog.SendRequest(1, parameter, i);

                        foreach (var catalog in CatalogURLList)
                        {
                            // Check if the catalog already exists in the database
                            if (!existingCatalogs.Contains(catalog.TrendyolProductURL))
                            {
                                _dashboardContext.ProductURL.Add(catalog);
                                _dashboardContext.SaveChanges();
                                existingCatalogs.Add(catalog.TrendyolProductURL); // Add to the list of existing URLs
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    // _log.Error(DateTime.Now.ToString() + ex.ToString());
                    //  _log.Info(DateTime.Now.ToString() + "An issue occured!");

                     }

                }





            return CatalogURLList.Take(20).ToArray();
        }
    }
}
