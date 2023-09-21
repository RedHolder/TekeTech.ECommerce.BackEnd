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

namespace TrendyolProduct.Api
{
    public class GetProductDetailsByURL
    {
       

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

            // Use regular expression to find the specified string
            MatchCollection match1 = Regex.Matches(y, productNameGeneralPattern);
            MatchCollection territoryMatch = Regex.Matches(y, territoryPattern);
            MatchCollection findPriceMatch = Regex.Matches(y, findPricePattern);
            MatchCollection shippingMatch2 = Regex.Matches(y, shippingPattern2);
            MatchCollection featuresMatch = Regex.Matches(y, featuresPattern);


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

            Product product = new Product();
            product.Id = Guid.NewGuid().ToString();
            product.ProductBrand = URLList3[0];
            product.ProductName = URLList3[1];
            product.ProductTerritory = URLList3[2];
            product.ProductPrice = URLList3[3];
            product.ProductSizes = URLList3[4];
            product.Stock = "1";
            product.ShipmentTime = URLList3[5];
            product.ProductFeatures = URLList3[6];
            product.ProductURL = URLList1;
            product.ProductChannel = "Trendyol";
            product.LastCheckDate = DateTime.Now;
            
            return product;

            }
            else
            {
                Console.WriteLine($"Error: {response.ErrorMessage}");
                return null;
            }
        }
    }
}
