using Microsoft.Extensions.FileSystemGlobbing.Internal;
using RestSharp;
using System;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace TrendyolProduct.Api
{
    public class GetProductListFromCategory
    {
        private String URL;
        private List<String>? CatalogURLList;


        public GetProductListFromCategory(){
            this.URL = "https://www.trendyol.com/";
        }

        public List<String> SendRequest(int ListSize, String SubUrl)
        {
            var client = new RestClient(URL);
            string RequestURLDetail = URL + SubUrl;//Bu URL front end'den gönderilecek. Kategorilerle birlikte saklanıyor.

            var request = new RestRequest(RequestURLDetail);
            var response = client.ExecuteGet(request);
            String responseContent = response.Content.ToString();

            if(responseContent != null)
            {
                this.CatalogURLList = GetCatalogURLList(responseContent);
            }
            else
            {
                //Log
            }

            
            return CatalogURLList ?? new List<String>();
        }

        public List<String> GetCatalogURLList(String responseContent)
        {
            List<String> CatalogURLList= new List<String>();
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

        public List<String> GetURLByPattern(String Pattern, String Content)
        {
            List<String> CatalogURLList = new List<String>();

            MatchCollection match = Regex.Matches(Content, Pattern);

            List<String> URLList = new List<String>();
            List<String> URLList1 = new List<String>();

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
                            CatalogURLList.Add(m.Groups[1].Value);
                        }
                        else { CatalogURLList.Add(m.Groups[1].Value); }

                    }
                }
            }
            return CatalogURLList;
        }
    }
}
