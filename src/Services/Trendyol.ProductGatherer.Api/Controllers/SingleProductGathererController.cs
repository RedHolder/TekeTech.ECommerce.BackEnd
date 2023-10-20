using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TrendyolProduct.Api;

namespace Trendyol.ProductGatherer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SingleProductGathererController : Controller
    {
        private readonly TyContext _context;

        public SingleProductGathererController(TyContext context)
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
        public IActionResult Get(
            int? productID = null,
            string? productURL = null)
        {




            var query = _context.Products
            .Where(p => string.IsNullOrEmpty(productURL) || p.ProductURL == productURL)
            .Where(p => (!productID.HasValue || productID == p.ProductId))
            .OrderBy(p => p.ProductId);

            var products = query.ToList();


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
