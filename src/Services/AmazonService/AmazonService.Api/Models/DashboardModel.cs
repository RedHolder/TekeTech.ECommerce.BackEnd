namespace AmazonService.Api.Models
{
    public class DashboardModel
    {
        public string Card1 { get; set; }
        public string Card2 { get; set; }
        public string Card3 { get; set; }
        public string Card4 { get; set; }
        public List<AmazonOrders> Orders { get; set; }
        public int BuyingPrice { get; set; }
        public int Unit { get; set; }

    }
    
}
