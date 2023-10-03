using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public class anakin
    {

        public List<string> links;
        public List<string> GetLinksFromPage(string url)
        {
            List<string> linkList = new List<string>();

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(url);

            // Tüm <a> etiketlerini bulma
            IList<IWebElement> anchorElements = driver.FindElements(By.TagName("a"));

            foreach (IWebElement element in anchorElements)
            {
                // Href özelliğini al ve listeye ekle
                string href = element.GetAttribute("href");
                if (!string.IsNullOrEmpty(href))
                {
                    linkList.Add(href);
                }
            }

            driver.Quit();

            return linkList;
        }

        public void GetReq()
        {
            string url = "https://www.hepsiburada.com/laptop-notebook-dizustu-bilgisayarlar-c-98";

            links = GetLinksFromPage(url);

            // Elde edilen bağlantıları kullanmak için burada işlem yapabilirsiniz
            
        }
    }
}
