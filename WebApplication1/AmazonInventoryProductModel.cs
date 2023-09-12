namespace WebApplication1
{
    public class Attributes
    {
        public List<ConditionType> condition_type { get; set; }
        public List<MerchantShippingGroup> merchant_shipping_group { get; set; }
        public List<MerchantSuggestedAsin> merchant_suggested_asin { get; set; }
        public List<PurchasableOffer> purchasable_offer { get; set; }
        public List<FulfillmentAvailability> fulfillment_availability { get; set; }
        public List<MainProductImageLocator> main_product_image_locator { get; set; }
        public List<OtherProductImageLocator1> other_product_image_locator_1 { get; set; }
        public List<OtherProductImageLocator2> other_product_image_locator_2 { get; set; }
    }

    public class ConditionType
    {
        public string value { get; set; }
        public string marketplace_id { get; set; }
    }

    public class FulfillmentAvailability
    {
        public string fulfillment_channel_code { get; set; }
        public int quantity { get; set; }
        public string marketplace_id { get; set; }
    }

    public class FulfillmentAvailability2
    {
        public string fulfillmentChannelCode { get; set; }
        public int quantity { get; set; }
    }

    public class Issue
    {
        public string message { get; set; }
        public string severity { get; set; }
        public string attributeName { get; set; }
        public List<string> attributeNames { get; set; }
    }

    public class MainImage
    {
        public string link { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }

    public class MainProductImageLocator
    {
        public string media_location { get; set; }
        public string marketplace_id { get; set; }
    }

    public class MerchantShippingGroup
    {
        public string value { get; set; }
        public string marketplace_id { get; set; }
    }

    public class MerchantSuggestedAsin
    {
        public string value { get; set; }
        public string marketplace_id { get; set; }
    }

    public class Offer
    {
        public string marketplaceId { get; set; }
        public string offerType { get; set; }
        public Price price { get; set; }
    }

    public class OtherProductImageLocator1
    {
        public string media_location { get; set; }
        public string marketplace_id { get; set; }
    }

    public class OtherProductImageLocator2
    {
        public string media_location { get; set; }
        public string marketplace_id { get; set; }
    }

    public class OurPrice
    {
        public List<Schedule> schedule { get; set; }
    }

    public class Price
    {
        public string currency { get; set; }
        public string amount { get; set; }
    }

    public class PurchasableOffer
    {
        public string currency { get; set; }
        public StartAt start_at { get; set; }
        public List<OurPrice> our_price { get; set; }
        public string marketplace_id { get; set; }
    }

    public class AmazonInventoryProductModel
    {
        public string sku { get; set; }
        public List<Summary> summaries { get; set; }
        public Attributes attributes { get; set; }
        public List<Issue> issues { get; set; }
        public List<Offer> offers { get; set; }
        public List<FulfillmentAvailability> fulfillmentAvailability { get; set; }
    }

    public class Schedule
    {
        public double value_with_tax { get; set; }
    }

    public class StartAt
    {
        public DateTime value { get; set; }
    }

    public class Summary
    {
        public string marketplaceId { get; set; }
        public string asin { get; set; }
        public string productType { get; set; }
        public string conditionType { get; set; }
        public List<string> status { get; set; }
        public string itemName { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime lastUpdatedDate { get; set; }
        public MainImage mainImage { get; set; }
    }


}
