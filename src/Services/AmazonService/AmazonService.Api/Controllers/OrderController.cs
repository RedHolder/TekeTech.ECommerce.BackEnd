using AmazonService.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OrderController(DatabaseContext context)
        {
            _context = context;
        }

       
        [HttpPost]
        public async Task<string> Post(AmazonOrders order)
        {
            // BarcodeNumber özelliğini otomatik olarak oluşturun
            order.BarcodeNumber = GenerateBarcodeNumber();

            _context.AmazonOrders.Add(order);
            await _context.SaveChangesAsync();

            return "200";
        }


        private bool OrderExists(string id)
        {
            return _context.AmazonOrders.Any(e => e.Id == id);
        }

        // Yeni bir barkod numarası oluşturan metot
        private string GenerateBarcodeNumber()
        {
            
            Random random = new Random();
            int randomNumber = random.Next(10000000, 99999999); // Örnek: 10000 ile 99999 arasında bir sayı alır
            return "BAR" + randomNumber.ToString();
        }
    }
}
