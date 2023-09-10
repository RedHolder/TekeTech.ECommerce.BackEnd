namespace WebApplication1
{
    public class TrendyolProductModel
    {
        public string FinalBrandName;
        public string FinalProductName;
        public string FinalTerritoryName;
        public string FinalPrice;
        public string FinalSizes;
        public string FinalStock;
        public string ProductURL;
        public string ProductChannel;

        public TrendyolProductModel(string FinalBrandName, string FinalProductName, string FinalTerritoryName, string FinalPrice, string FinalSizes, string FinalStock, string ProductURL, string ProductChannel)
        {
            this.FinalBrandName = FinalBrandName;
            this.FinalProductName = FinalProductName;
            this.FinalTerritoryName = FinalTerritoryName;
            this.FinalPrice = FinalPrice;
            this.FinalSizes = FinalSizes;
            this.FinalStock = FinalStock;
            this.ProductURL = ProductURL;
            this.ProductChannel = ProductChannel;
        }
    }
}
