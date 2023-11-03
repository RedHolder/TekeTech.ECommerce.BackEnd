using AmazonService.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardMainController : Controller
    {

        private List<AmazonOrders>? AmazonOrders;
        private List<DashboardModel> DashboardModels;

        private readonly DatabaseContext _dashboardContext;

        public DashboardMainController(DatabaseContext dashboardContext)
        {
           
            _dashboardContext = dashboardContext;
        }

       

        [HttpGet("{days}", Name = "GetDashboardContent")]
        public List<DashboardModel> Get(int days)
        {
            if (days <= 0)
            {
                
                return new List<DashboardModel>();
            }

            
            List<DashboardModel> DashboardModels = new List<DashboardModel>();

            var groupedOrders = _dashboardContext.AmazonOrders
                .GroupBy(order => order.OrderDate.Date)
                .ToList();

            foreach (var group in groupedOrders)
            {
               
                var dm = new DashboardModel();

                
                dm.Card1 = group.Sum(order => order.SalePrice).ToString(); // Günlük toplam SalePrice
                dm.Card2 = (group.Sum(order => order.SalePrice) - group.Sum(order => order.BuyingPrice)).ToString(); // Günlük SalePrice - BuyingPrice
                dm.Card3 = ((float)group.Count(order => order.DeliveryDate != null) / group.Count()).ToString(); // Delivery Date'i null olmayan ürünlerin oranı
                dm.Card4 = "17"; // Sabit değer

                dm.Orders = group.ToList(); // Günlük siparişler
                dm.BuyingPrice = group.Sum(order => order.BuyingPrice); // Günlük Buying price'ların toplamı
                dm.Unit = group.Count(); // Günlük siparişlerin toplam sayısı

                DashboardModels.Add(dm);
            }

            DashboardModels = DashboardModels
                .Where(dm => (DateTime.Now.Date - dm.Orders.First().OrderDate.Date).TotalDays <= days)
                .ToList();

            return DashboardModels;
        }
    }
}

