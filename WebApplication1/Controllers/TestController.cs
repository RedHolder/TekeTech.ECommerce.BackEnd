using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private static readonly string[] Summaries = new[]
     {
        "Pembesi", "Gtti", "Tozu", "Kaldı", "Senin"
    };



        private readonly ILogger<WeatherForecastController> _logger;

        public TestController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBasket")]
        public IEnumerable<AmazonInventoryProductModel> Get()
        {


            
            TestClass testClass = new TestClass();
            testClass.getReq();
            AmazonGetProduct amazonGetProduct = new AmazonGetProduct();
            amazonGetProduct.getProductListFromAmazon();

            return Enumerable.Range(1, 5).Select(index => amazonGetProduct.AmazonProducts);
        }
    }
}
