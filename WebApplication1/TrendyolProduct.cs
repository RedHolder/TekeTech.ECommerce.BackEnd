using RestSharp;
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

namespace WebApplication1
{
    public class TrendyolProduct
    {
        public List<TrendyolProductModel> trendyolProductModels;

        public async Task GetReqAsync(string subURL, int page)
        {
            trendyolProductModels = new List<TrendyolProductModel>();
            var client = new HttpClient();
            string requestURLDetail = "https://www.trendyol.com/" + subURL + "?pi=" + page.ToString();

            var response = await client.GetStringAsync(requestURLDetail);
            var y = response;

            string startPattern = "<div class=\"prdct-cntnr-wrppr\">";
            string endPattern = "<div class=\"virtual\">";

            // Use regular expressions to find the substrings
            Regex startRegex = new Regex(Regex.Escape(startPattern) + "(.*?)" + Regex.Escape(endPattern));
            Match match2 = startRegex.Match(y);

            var x = match2.Groups[1].Value;



            string pattern = "<a\\s+href=\"(.*?)\">";

            // Use regular expression to find the specified string
            MatchCollection match = Regex.Matches(x, pattern);

            List<String> URLList = new List<String>();
            List<String> URLList1 = new List<String>();
            foreach (Match m in match)
            {
                if (m.Success)
                {
                    URLList.Add(m.Groups[1].Value);
                }
            }
            foreach (String mat in URLList)
            {


                if (!mat.Contains("magaza"))
                {
                    string s = mat;
                    if (mat.Contains("target"))
                    {
                        s = mat.Substring(0, mat.IndexOf("\""));
                        URLList1.Add(s);
                    }
                    else { URLList1.Add(s); }


                }
            }
           
            var tasks = new Task[URLList1.Count];

            for (int i = 0; i < URLList1.Count; i++)
            {
                tasks[i] = GetProductDetailsAsync(URLList1[i]);
            }

            await Task.WhenAll(tasks);
        }

        public async Task GetProductDetailsAsync(string URLList1)
        {
            Console.WriteLine(URLList1);
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            var client = new HttpClient();
            string requestURLDetail = "https://www.trendyol.com" + URLList1;

            var response = await client.GetStringAsync(requestURLDetail);
            var y = response;





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
            MatchCollection findPriceMatch= Regex.Matches(y, findPricePattern);
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


            if (featuresMatch.Count > 1) { 
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


            TrendyolProductModel trendyolProduct = new TrendyolProductModel(URLList3[0], URLList3[1], URLList3[2], URLList3[3], URLList3[4], "1", URLList3[5], URLList3[6],URLList1, "Trendyol");
            trendyolProductModels.Add(trendyolProduct);
        }
    }
}
