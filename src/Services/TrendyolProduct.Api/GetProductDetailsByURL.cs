using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;
using System.Reflection.Emit;
using System;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;
using TrendyolProduct.Api.Models;
using RestSharp;
using System.Security.Policy;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrendyolProduct.Api
{
    public class GetProductDetailsByURL
    {

        private TyContext _context; // DbContext'i kullanabilmek için

        public GetProductDetailsByURL(TyContext context)
        {
            _context = context;
        }

        public Product GetProductDetailsAsync(string URLList1)
        {


            var client = new RestClient("https://www.trendyol.com");
            

            var request = new RestRequest(URLList1, Method.Get);

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string y = response.Content;
                // Now 'y' contains the response content
           





            string productNameGeneralPattern = "<h1 class=\"pr-new-br\" data-drroot=\"h1\">(.*?)</h1>";
            string brandNamePattern = "<span class=\"product-brand-name-without-link\">(.*?)</span>";
            string brandNamePatternWithLink = "<a class=\"product-brand-name-with-link\" href=\"(.*?)</a>";
            string productNamePattern = "<span>(.*?)</span>";
            string territoryPattern = "<span id=\"cityInfo\">Şehir:<b>(.*?)</b></span>";
            string findPricePattern = "<div class=\"product-detail-wrapper\">(.*?)<div class=\"product-info-badges\">";
            string pricePattern = "<span class=\"prc-dsc\">(.*?)</span>";
            string sizePattern = "Beden seçmek için tıklayınız\">(.*?)</div>";
            string shippingPattern = "<div class=\"pr-dd-rs-w\"><i class=\"i-my-orders\"></i><span class=\"pr-dd-nr-text\">Tahmini Kargoya Teslim: </span><span class=\"dd-txt-vl\">(.*?)</span>";
            string shippingPattern2 = "<strong>en geç yarın</strong>";
            string featuresPattern = "<ul class=\"detail-attr-container\">(.*?)</ul";
            string Sellerpattern = @"<span>Satıcı Ünvanı<b>\s*(.*?)\s*</b></span>";

                List<string> urlList = ExtractUrlsFromDiv(y);

                if (urlList.Count == 0)
                {
                    urlList.Add("yok");
                }

                foreach (string url in urlList)
                {
                    Console.WriteLine(url);
                }

                // Use regular expression to find the specified string
            MatchCollection match1 = Regex.Matches(y, productNameGeneralPattern);
            MatchCollection territoryMatch = Regex.Matches(y, territoryPattern);
            MatchCollection findPriceMatch = Regex.Matches(y, findPricePattern);
            MatchCollection shippingMatch2 = Regex.Matches(y, shippingPattern2);
            MatchCollection featuresMatch = Regex.Matches(y, featuresPattern);
            Match Sellermatch = Regex.Match(y, Sellerpattern);

                Product product = new Product();


                MatchCollection priceMatch = Regex.Matches(findPriceMatch[0].Groups[1].Value, pricePattern);



            MatchCollection sizeMatch = Regex.Matches(y, sizePattern);


            List<String> URLList2 = new List<String>();
            List<String> URLList3 = new List<String>();
            foreach (Match m in match1)
            {
                if (m.Success)
                {
                    URLList2.Add(m.Groups[1].Value);
                }
            }
            MatchCollection brandMatch = Regex.Matches(URLList2[0], brandNamePattern);
            MatchCollection productMatch = Regex.Matches(URLList2[0], productNamePattern);

            if (brandMatch.Count < 1)
            {
                brandMatch = Regex.Matches(URLList2[0], brandNamePatternWithLink);
            }
            foreach (Match m in brandMatch)
            {
                if (m.Success)
                {
                    if (m.Groups[1].Value.Contains("\">"))
                    {
                        string s = m.Groups[1].Value;
                        string FinalValue = s.Substring(s.IndexOf(">") + 1);
                        URLList3.Add(FinalValue);

                    }
                    else
                    {

                        URLList3.Add(m.Groups[1].Value);
                    }
                }
            }
            foreach (Match m in productMatch)
            {
                if (m.Success)
                {
                    URLList3.Add(m.Groups[1].Value);
                }
            }

            for (int iss = 0; iss < 1; iss++)
            {
                if (territoryMatch[iss].Success)
                {
                    URLList3.Add(territoryMatch[iss].Groups[1].Value);

                }
            }
            foreach (Match m in priceMatch)
            {
                if (m.Success)
                {
                    URLList3.Add(m.Groups[1].Value);
                }
            }
            string sa = "";
            foreach (Match m in sizeMatch)
            {
                if (m.Success)
                {
                    if (!m.Groups[1].Value.Contains("notice-alarm"))
                    {
                        sa += m.Groups[1].Value + ", ";
                    }
                }
            }

            URLList3.Add(sa);

            if (shippingMatch2.Count < 1)
            {
                MatchCollection shippingMatch = Regex.Matches(y, shippingPattern);


                foreach (Match m in shippingMatch)
                {
                    if (m.Success)
                    {
                        URLList3.Add(m.Groups[1].Value);

                    }
                }
            }
            else { URLList3.Add("1 Gün içinde"); }


            if (featuresMatch.Count > 1)
            {
                foreach (Match m in featuresMatch)
                {
                    if (m.Success)
                    {
                        URLList3.Add(m.Groups[1].Value);
                    }
                }
            }
            else
            {
                URLList3.Add("There is no features to show!");
            }


            if (Sellermatch.Success)
            {
                    // Eşleşen metni al
             string foundText = Sellermatch.Groups[1].Value;
             product.SellerName = foundText;
            }
                else
                {
                    product.SellerName = "";
                }


            product.Brand = URLList3[0];
            product.ProductName = URLList3[1];
            product.City = URLList3[2];
            product.Price = URLList3[3];
            product.Sizes = URLList3[4];
            product.Inventory = 1;
            product.ShipmentDay = URLList3[5];
            product.Features = URLList3[6];
            product.ProductURL = URLList1;
            product.MarketPlace = "Trendyol";
            product.LastCheckDate = DateTime.Now;

          
                try
                {
                    List<Product> productsToDelete = _context.Products.Where(p => p.ProductURL == product.ProductURL).ToList();

                    // Her bir ürünü sildikten sonra yeni ürün bilgilerini ekleyin
                    foreach (var products in productsToDelete)
                    {
                        _context.Products.Remove(product);
                    }

                    _context.Products.Add(product);
                }
                catch (Exception ex)
                {

                    //log
                }

                foreach (string url in urlList)
                {
                    var media = new Media { MediaURL = url };
                    _context.Medias.Add(media);

                    var productMedia = new ProductMedia
                    {
                        Product = product,
                        Media = media
                    };
                    _context.ProductMedias.Add(productMedia);
                }

                

                List<Review> reviews = GetReview(URLList1);

                foreach (Review review in reviews)
                {
                   
                    _context.Reviews.Add(review);

                    var productReview = new ProductReview
                    {
                        Product = product,
                        Review = review
                    };
                    _context.ProductReviews.Add(productReview);
                }
                _context.SaveChanges();
                return product;

            }
            else
            {
                Console.WriteLine($"Error: {response.ErrorMessage}");
                return null;
            }
        }

        public List<string> ExtractUrlsFromDiv(string html)
        {
            List<string> urls = new List<string>();
            string divPattern = "<div class=\"gallery-container(.*?)<div class=\"container-right-content\">"; // Regex pattern for the inner div content

            Match divMatch = Regex.Match(html, divPattern, RegexOptions.Singleline);

            if (divMatch.Success)
            {
                string divContent = divMatch.Groups[1].Value;
                string urlPattern = @"src=\""([^\""]+)\"""; // Regex pattern to match src attributes

                MatchCollection matches = Regex.Matches(divContent, urlPattern);

                foreach (Match match in matches)
                {
                    string url = match.Groups[1].Value;
                    urls.Add(url);
                }
            }

            return urls;
        }

        public List<Review> GetReview(string productURL)
        {
            productURL = "https://www.trendyol.com" + productURL;
            Uri uri = new Uri(productURL);

            // Get the segments of the URL
            string[] segments = uri.Segments;

            // Find the segment that contains "p-" and extract the number
            string productId = null;
            foreach (string segment in segments)
            {

                if (segment.Contains("p-"))
                {
                    int startIndex = segment.IndexOf("p-");
                    if (startIndex != -1)
                    {
                         productId = segment.Substring(startIndex + 2);
                        
                    }
                    break;
                }
            }

            var reviews = new List<Review>();

            if (productId != null)
            {

                var client = new RestClient("https://public-mdc.trendyol.com/");


                var request = new RestRequest("discovery-web-socialgw-service/api/review/" + productId, Method.Get);

                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    string y = response.Content;

                    JObject data = JsonConvert.DeserializeObject<JObject>(y);
                    JArray contentArray = data["result"]["productReviews"]["content"] as JArray;

                    foreach (var reviewData in contentArray)
                    {
                        var review = new Review
                        {
                            UserID = (int)reviewData["id"],
                            Content = (string)reviewData["comment"],
                            Rating = (int)reviewData["rate"]
                        };

                        reviews.Add(review);
                    }

                    return reviews;
                }
                else
                {
                    
                    return reviews;
                }


            }
            else
            {
                return reviews;
            }
        }
    }
}
