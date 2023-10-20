namespace TrendyolProduct.Api.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Price { get; set; }
        public string ShipmentDay { get; set; }
        public string Features { get; set; }
        public string Sizes { get; set; }
        public int Inventory { get; set; }
        public string SellerName { get; set; }
        public string City { get; set; }
        public string MarketPlace { get; set; }
        public string ProductURL { get; set; }
        public int CategoryId { get; set; }
        public DateTime LastCheckDate { get; set; }
        public List<ProductMedia> ProductMedia { get; internal set; }
        public List<ProductReview> ProductReview { get; internal set; }
        public List<ProductCampaign> ProductCampaign { get; internal set; }
    }

   

    public class ProductMedia
    {
        public int ProductMediaId { get; set; }
        public int ProductId { get; set; }
        public int MediaId { get; set; }
        public Media Media { get; internal set; }
        
    }

    public class Media
    {
        public int MediaId { get; set; }
        public string MediaURL { get; set; }
    }

    public class ProductReview
    {
        public int ProductReviewId { get; set; }
        public int ProductId { get; set; }
        public int? ReviewId { get; set; } // ReviewId artık nullable
        public Review? Review { get; set; } // Review artık nullable
    }

    public class Review
    {
        public int ReviewId { get; set; }
        public int UserID { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        
    }

    public class ProductCampaign
    {
        public int ProductCampaignId { get; set; }
        public int ProductId { get; set; }
        public int? CampaignId { get; set; }
        public Campaign? Campaign { get; set; } // Campaign artık nullable
    }

    public class Campaign
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float DiscountRate { get; set; }
    }
}
