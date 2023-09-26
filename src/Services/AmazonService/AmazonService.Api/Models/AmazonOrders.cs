namespace AmazonService.Api.Models
{
    public class AmazonOrders
    {
        public string Id { get; set; }
        public string OrderNumber { get; set; }
        public string BarcodeNumber { get; set; }
        public int StatusID { get; set; }
        public int BuyingPrice { get; set; }
        public int SalePrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ConfirmDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ShipmentID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string OrderChannel { get; set; }
        public string MarketPlace { get; set; }
    }
}
