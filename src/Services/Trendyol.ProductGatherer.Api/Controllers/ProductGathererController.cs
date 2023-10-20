using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace TrendyolProduct.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGathererController : Controller
    {
        private readonly TyContext _context;

        public ProductGathererController(TyContext context)
        {
            _context = context;
        }

        float ParsePrice(string priceString)
        {
            if (float.TryParse(priceString, NumberStyles.Currency, CultureInfo.GetCultureInfo("tr-TR"), out float result))
            {
                return result;
            }
            return 0.0f; 
        }

        [HttpGet]
        public  IActionResult Get(
            int category,
            int pi = 1,
            string brand = null,
            float? LP = null,
            float? HP = null)
        {
            int pageSize = 20; // Sayfa başına ürün sayısı
            int skipCount = (pi - 1) * pageSize;
            

            
            var query = _context.Products
            .Where(p => (category > 0) || p.CategoryId == category)
            .Where(p => string.IsNullOrEmpty(brand) || p.Brand == brand)
            .Where(p => (!LP.HasValue || ParsePrice(p.Price) >= LP.Value) && (!HP.HasValue || ParsePrice(p.Price) <= HP.Value))
            .OrderBy(p => p.ProductId)
            .Skip(skipCount)
            .Take(pageSize);

            var products =  query.ToList();

            
            foreach (var product in products)
            {
                int i = 2;
                product.ProductMedia = _context.ProductMedias
                    .Where(pm => pm.ProductId == product.ProductId)
                    .ToList();
                
           
                product.ProductReview = _context.ProductReviews
                    .Where(pr => pr.ProductId == product.ProductId)
                    .ToList();
            

                product.ProductCampaign = _context.ProductCampaigns
                    .Where(pc => pc.ProductId == product.ProductId)
                    .ToList();
            }

            return Ok(products);
        }
    }
}
