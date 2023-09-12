using RestSharp;
using Newtonsoft.Json;

namespace WebApplication1
{
    public class AmazonGetProduct
    {

        public AmazonInventoryProductModel AmazonProducts;

        public void getProductListFromAmazon()
        {
            var client = new RestClient("https://sellingpartnerapi-na.amazon.com");
            string RequestURLDetail = "/listings/2021-08-01/items/AXXXXXXXXXXXX/50-TS3D-QEPT?marketplaceIds=ATVPDKIKX0DER&issueLocale=en_US&includedData=issues,attributes,summaries,offers,fulfillmentAvailability";//Bu URL front end'den gönderilecek. Kategorilerle birlikte saklanıyor.

            var request = new RestRequest(RequestURLDetail);
            var response = client.ExecuteGet(request);
            var y = response.Content;


            AmazonProducts = JsonConvert.DeserializeObject<AmazonInventoryProductModel>(y);// Burada parçladık ve ram'de tutuyoruz. İster Front end'e yollarız ister db'ye;


        }
    }
}
