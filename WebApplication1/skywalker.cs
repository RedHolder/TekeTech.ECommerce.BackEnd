using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public class skywalker
    {
        public List<string> GetPricesFromPage(string url)
        {
            List<string> priceList = new List<string>();

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(url);

            // Tüm <span> etiketlerini bulma
            IList<IWebElement> spanElements = driver.FindElements(By.TagName("span"));

            foreach (IWebElement element in spanElements)
            {
                // data-bind özelliği "markupText:'currentPriceBeforePoint'" olanları bulma
                string dataBindValue = element.GetAttribute("data-bind");
                if (!string.IsNullOrEmpty(dataBindValue) && dataBindValue.Contains("markupText:'currentPriceBeforePoint'"))
                {
                    // <span> etiketinin içeriğini al ve listeye ekle
                    string price = element.Text;
                    priceList.Add(price);
                }
            }

            driver.Quit();

            return priceList;
        }

        public void GetPrices()
        {
            string url = "URL_OF_YOUR_PAGE_HERE";

            List<string> prices = GetPricesFromPage(url);

            // Elde edilen fiyatları kullanmak için burada işlem yapabilirsiniz
            foreach (string price in prices)
            {
                Console.WriteLine(price);
            }
        }
    }
}
