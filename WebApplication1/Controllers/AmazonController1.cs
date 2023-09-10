using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Amazon> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Amazon
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                para = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
