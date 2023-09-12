﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AmazonController1 : Controller
    {

        private static readonly string[] Summaries = new[]
        {
        "Pembesi", "Gtti", "Tozu", "Kaldı", "Senin"
    };



        private readonly ILogger<WeatherForecastController> _logger;

        public AmazonController1(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAmazonController1")]
        public IEnumerable<AmazonInventoryProductModel> Get()
        {
            AmazonGetProduct amazonGetProduct = new AmazonGetProduct();
            amazonGetProduct.getProductListFromAmazon();

            return Enumerable.Range(1, 5).Select(index => amazonGetProduct.AmazonProducts);
        }
    }
}
