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

namespace WebApplication1
{
    public class TrendyolProduct
    {
        public List<TrendyolProductModel> trendyolProductModels;

        public void getreq(string SubURL)
        {
            trendyolProductModels = new List<TrendyolProductModel>();
            // send GET request with RestSharp
            var client = new RestClient("https://www.trendyol.com");
            string RequestURLDetail = "https://www.trendyol.com/" + SubURL;//Bu URL front end'den gönderilecek. Kategorilerle birlikte saklanıyor.
            long  id = 112227760;




            var request = new RestRequest(RequestURLDetail);
            var response = client.ExecuteGet(request);
            var y = response.Content; //search sonucunu analiz için aldım. Html page elimizde. Buradann linkin altındaki ilk x sayıda ürünü alacağız

            string startPattern = "<div class=\"prdct-cntnr-wrppr\">";
            string endPattern = "<div class=\"virtual\">";

            // Use regular expressions to find the substrings
            Regex startRegex = new Regex(Regex.Escape(startPattern) + "(.*?)" + Regex.Escape(endPattern));
            Match match2 = startRegex.Match(y);

            var x= match2.Groups[1].Value;



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
            foreach(String mat in URLList) {

               
                if (!mat.Contains("magaza")) {
                    string s = mat;
                    if (mat.Contains("target")){
                        s = mat.Substring(0, mat.IndexOf("\""));
                        URLList1.Add(s);
                    }
                    else { URLList1.Add(s); }

                string readText = File.ReadAllText(@"C:\File\test.txt");
                using (StreamWriter writer = new StreamWriter(@"C:\File\test.txt"))
                {
                    
                   // writer.WriteLine(readText + s.ToString()); //Sayfadaki Ürün Linklerini Çıkardık. Text Dosyasına Yazdık Şimdilik
                  //  writer.WriteLine("");
                }
                }
            }

            foreach(String CurrentUrl in URLList1)
            {

                getProductDetails(CurrentUrl);
            }


            //\"prdct-cntnr-wrppr\" class id'li div ayıklanacak

            //Ayıklandı
            //Şimdi aynı işi url üzerinden yapıp ürün özelinde veri çekilecek





        }


        public void getProductDetails(String URLList1)
        {
            var client = new RestClient("https://www.trendyol.com");
            string RequestURLDetail = RequestURLDetail = "https://www.trendyol.com" + URLList1;//Bu URL front end'den gönderilecek. Kategorilerle birlikte saklanıyor.

           

            var request = new RestRequest(RequestURLDetail);
            var response = client.ExecuteGet(request);
            var y = response.Content;





            string productNameGeneralPattern = "<h1 class=\"pr-new-br\" data-drroot=\"h1\">(.*?)</h1>";
            string brandNamePattern = "<span class=\"product-brand-name-without-link\">(.*?)</span>";
            string brandNamePatternWithLink = "<a class=\"product-brand-name-with-link\" href=\"(.*?)</a>";
            string productNamePattern = "<span>(.*?)</span>";
            string territoryPattern = "<span id=\"cityInfo\">Şehir:<b>(.*?)</b></span>";
            string pricePattern = "<span class=\"prc-dsc\">(.*?)</span>";
            string sizePattern = "Beden seçmek için tıklayınız\">(.*?)</div>";

            // Use regular expression to find the specified string
            MatchCollection match1 = Regex.Matches(y, productNameGeneralPattern);
            MatchCollection territoryMatch = Regex.Matches(y, territoryPattern);
            MatchCollection priceMatch = Regex.Matches(y, pricePattern);
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
            foreach (String mat in URLList3)
            {

                string s = mat;

                string readText = File.ReadAllText(@"C:\File\test.txt");
                using (StreamWriter writer = new StreamWriter(@"C:\File\test.txt"))
                {

                    writer.WriteLine(readText + s.ToString()); //Sayfadaki Ürün Linklerini Çıkardık. Text Dosyasına Yazdık Şimdilik
                    writer.WriteLine("");
                }

            }


            TrendyolProductModel trendyolProduct = new TrendyolProductModel(URLList3[0], URLList3[1], URLList3[2], URLList3[3], URLList3[4], "1", URLList1, "Trendyol");
            trendyolProductModels.Add(trendyolProduct);
           
        }
    }
}
