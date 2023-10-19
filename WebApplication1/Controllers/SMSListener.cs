using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

        [ApiController]
        [Route("[controller]")]
        public class SMSListener : Controller
        {
            private static readonly string[] Summaries = new[]
         {
        "Pembesi", "Gtti", "Tozu", "Kaldı", "Senin"
    };



            private readonly ILogger<WeatherForecastController> _logger;

            public SMSListener(ILogger<WeatherForecastController> logger)
            {
                _logger = logger;
            }

        [HttpPost("POSTSMS")] // Define a POST method with the name "POSTSMS"
        public IActionResult Post([FromBody] string smsData)
        {
            try
            {
                // SMS verisini text.txt dosyasına yazma işlemi
                string filePath = @"C:\File\text.txt";
                System.IO.File.WriteAllText(filePath, smsData);

                // Başarılı yanıt döndürme
                return Ok("SMS başarıyla alındı ve dosyaya yazıldı.");
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun yanıtı döndürme
                return BadRequest($"SMS kaydedilirken bir hata oluştu: {ex.Message}");
            }
        }
    }
}
