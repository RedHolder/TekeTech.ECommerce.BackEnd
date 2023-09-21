using AmazonService.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AmazonService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ASINController : Controller
    {
        
        private List<ASIN>? CatalogURLList;

        private readonly DatabaseContext _dashboardContext;

        public ASINController(DatabaseContext dashboardContext)
        {
            // _log = LogManager.GetLogger(typeof(ProductTrendyolController));
            _dashboardContext = dashboardContext;
        }

        [HttpGet("{parameter}", Name = "CreateASIN")]
        public IEnumerable<ASIN> Get(string parameter)
        {

            CreateASIN createASIN = new CreateASIN();
            var existingCatalogs = _dashboardContext.ASIN.Select(p => p.ASINCode).ToList();

            for (int i = 0; i < 1000; i++)
            {
                var AsinCode = new ASIN
                {
                    Id = Guid.NewGuid().ToString(),
                    ASINCode = createASIN.CreateASINCode(),
                    IsUsed = false
                };
                if (!existingCatalogs.Contains(AsinCode.ASINCode))
                {
                     _dashboardContext.ASIN.Add(AsinCode);
                     _dashboardContext.SaveChanges();
                     existingCatalogs.Add(AsinCode.ASINCode);
                }
                else { i--; }
            }
         
            return null;
        }
    }
}
