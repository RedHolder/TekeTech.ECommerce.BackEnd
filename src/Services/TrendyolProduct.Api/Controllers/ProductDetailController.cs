using Microsoft.AspNetCore.Mvc;
using TrendyolProduct.Api.Models;

namespace TrendyolProduct.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductDetailController : Controller
    {
        private GetProductDetailsByURL GetCatalog;
        private List<ProductURL>? CatalogURLList;

        private readonly TyContext _dashboardContext;

        public ProductDetailController(TyContext dashboardContext)
        {
            _dashboardContext = dashboardContext;
        }

        [HttpGet(Name = "GetProductDetailTrendyol")]
        public IEnumerable<ProductURL> Get()
        {
            GetCatalog = new GetProductDetailsByURL(_dashboardContext);
            
            CatalogURLList = _dashboardContext.ProductURL.ToList();
            int i = 0;
           
            foreach (var catalog in CatalogURLList)
            {
                try
                {
                  GetCatalog.GetProductDetailsAsync(catalog.TrendyolProductURL);
                }
                catch(Exception ex) { 
                
                    //log
                }

                
            }

            return Enumerable.Range(1, 20).Select(index => new ProductURL
            {
                CategoryID = "1",
                Id = "",
                TrendyolProductURL = ""
            })
            .ToArray();
        }


    }
}
