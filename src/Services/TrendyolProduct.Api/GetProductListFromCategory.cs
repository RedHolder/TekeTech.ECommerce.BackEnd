using Microsoft.Extensions.FileSystemGlobbing.Internal;
using RestSharp;
using System;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using TrendyolProduct.Api.Models;

namespace TrendyolProduct.Api
{
    public class GetProductListFromCategory
    {
        private String URL;
        private String SubURL;
        private List<ProductURL>? CatalogURLList;


        public GetProductListFromCategory(){
            this.URL = "https://www.trendyol.com/";
            CatalogURLList = new List<ProductURL>();
        }

        public List<ProductURL> SendRequest(int ListSize, String SubUrl, int page)
        {
            var client = new RestClient(URL);
            string RequestURLDetail = URL + SubUrl + "?pi=" + page.ToString(); ;//Bu URL front end'den gönderilecek. Kategorilerle birlikte saklanıyor.

            var request = new RestRequest(RequestURLDetail);
            var response = client.ExecuteGet(request);
            String responseContent = response.Content.ToString();

            this.SubURL = SubUrl;

            if(responseContent != null)
            {
                this.CatalogURLList = GetCatalogURLList(responseContent);
            }
            else
            {
                //Log
            }

            
            return CatalogURLList ?? new List<ProductURL>();
        }

        public List<ProductURL> GetCatalogURLList(String responseContent)
        {
            List<ProductURL> CatalogURLList= new List<ProductURL>();
            String StartPattern = "<div class=\"prdct-cntnr-wrppr\">";
            String EndPattern = "<div class=\"virtual\">";
            String Content= GetURLByPattern(StartPattern, EndPattern, responseContent);
            StartPattern = "<a\\s+href=\"(.*?)\">";
            CatalogURLList = GetURLByPattern(StartPattern, Content);

            return CatalogURLList;
        }

        public String GetURLByPattern(String StartPattern, String EndPattern, String Content) {

            // Use regular expressions to find the substrings
            Regex startRegex = new Regex(Regex.Escape(StartPattern) + "(.*?)" + Regex.Escape(EndPattern));
            Match match2 = startRegex.Match(Content);

            var Result = match2.Groups[1].Value;

            return Result;
        }

        public List<ProductURL> GetURLByPattern(String Pattern, String Content)
        {
            List<ProductURL> CatalogURLList = new List<ProductURL>();

            MatchCollection match = Regex.Matches(Content, Pattern);

            List<String> URLList = new List<String>();
            List<String> URLList1 = new List<String>();
            String URL;
            foreach (Match m in match)
            {
                if (m.Success)
                {
                    if (!m.Groups[1].Value.Contains("magaza"))
                    {
                        string s = m.Groups[1].Value;
                        if (m.Groups[1].Value.Contains("target"))
                        {
                            s = m.Groups[1].Value.Substring(0, m.Groups[1].Value.IndexOf("\""));
                            URL=m.Groups[1].Value;
                        }
                        else { URL = m.Groups[1].Value; }
                        ProductURL productURL = new ProductURL();
                        productURL.Id = Guid.NewGuid().ToString();
                        productURL.TrendyolProductURL = URL;
                        productURL.CategoryID = SubURL;
                        CatalogURLList.Add(productURL);
                    }
                }
            }
            return CatalogURLList;
        }
    }
}
