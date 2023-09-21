namespace TrendyolProduct.Api.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string ProductBrand { get; set; }
        public string ProductName { get; set; }
        public string ProductTerritory { get; set; }
        public string ProductPrice { get; set; }
        public string ProductSizes { get; set; }
        public string Stock { get; set; }
        public string ShipmentTime { get; set; }
        public string ProductFeatures { get; set; }
        public string ProductURL { get; set; }
        public string ProductChannel { get; set; }
        public DateTime LastCheckDate { get; set; }
    }
}
