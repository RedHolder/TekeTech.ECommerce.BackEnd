using AmazonService.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SKINController
    {

        private List<SKIN>? CatalogURLList;

        private readonly DatabaseContext _dashboardContext;

        public SKINController(DatabaseContext dashboardContext)
        {
            // _log = LogManager.GetLogger(typeof(ProductTrendyolController));
            _dashboardContext = dashboardContext;
        }

        [HttpGet("{parameter}", Name = "CreateSKIN")]
        public IEnumerable<SKIN> Get(string parameter)
        {

            CreateASIN createASIN = new CreateASIN();
            var existingCatalogs = _dashboardContext.SKIN.Select(p => p.SKINCode).ToList();

            for (int i = 0; i < 1000; i++)
            {
                var SkinCode = new SKIN
                {
                    Id = Guid.NewGuid().ToString(),
                    SKINCode = createASIN.CreateSKINCode(),
                    IsUsed = false
                };
                if (!existingCatalogs.Contains(SkinCode.SKINCode))
                {
                    _dashboardContext.SKIN.Add(SkinCode);
                    _dashboardContext.SaveChanges();
                    existingCatalogs.Add(SkinCode.SKINCode);
                }
                else { i--; }
            }

            return null;
        }
    }
}

