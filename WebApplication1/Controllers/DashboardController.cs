using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DashboardController : Controller
    {
        private readonly DashboardContext _dashboardContext;

        public DashboardController(DashboardContext context)
        {
            _dashboardContext = context;
        }

        [HttpGet("{parameter}", Name = "GetDashboardData")]
        public  IEnumerable<Orders> Get(string parameter)
        {
            var heroes = _dashboardContext.Orders.ToList();


            return heroes;
        }
    }
}
