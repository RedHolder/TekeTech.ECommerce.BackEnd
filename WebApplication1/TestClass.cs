using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using RestSharp;
using System;
using System.Linq;

namespace WebApplication1
{
    public class TestClass
    {

        public void getReq()
        {
            /*
            var client = new RestClient("https://www.facebook.com");
            string RequestURLDetail = "https://www.facebook.com/tr/?id=1434139333470513&ev=AddToCart&dl=https://www.trendyol.com/ac-co-altinyildiz-classics/erkek-siyah-100-pamuk-slim-fit-dar-kesim-bisiklet-yaka-kisa-kollu-tisort-p-220686963?boutiqueId=61&merchantId=347&rl=https://www.trendyol.com/sepet&if=false&ts=1694517679206&cd[contents]=[{\"id\":\"220686963_347\",\"quantity\":1,\"item_price\":139.99}]&cd[content_type]=product&cd[content_category]=T-Shirt&cd[butik_id]=61&cd[value]=139.99&cd[currency]=TRY&cd[user_type]=2&cd[buyerStatus]=0&cd[membertype]=null&cd[butik_bu]=Erkek A&cd[brand]=AC&Co / Altınyıldız Classics&sw=1920&sh=1080&ud[em]=d95b815ac298f0ff6105f4a6f5c05d8567b5fa9f64fb5e00b8fc41dd1f981578&v=2.9.125&r=stable&ec=3&o=30&fbp=fb.1.1665186022298.831240354&it=1694517660372&coo=false&eid=1694517659117.866792&rqm=GET";
            var request = new RestRequest(RequestURLDetail);
            var response = client.ExecuteGet(request);
            var y = response.Content;
            int i = 2;*/

            string url = "https://www.trendyol.com/ac-co-altinyildiz-classics/erkek-siyah-100-pamuk-slim-fit-dar-kesim-bisiklet-yaka-kisa-kollu-tisort-p-220686963";




            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();






            driver.Navigate().GoToUrl(url);


            bool elementFound = false;

            

            while (!elementFound)
            {
                try
                {
                    IWebElement loginButton1 = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
                    loginButton1.Click();
                    elementFound = true;
                }
                catch (NoSuchElementException)
                {
                    // Handle the exception (e.g., wait for a moment, retry, etc.)
                    Console.WriteLine("Element not found. Retrying...");
                    // You can add additional code here to wait or perform other actions between retries

                }
            }

            elementFound = false;
            while (!elementFound)
            {
                try
                {
                    IWebElement Anladim = driver.FindElement(By.CssSelector("div.campaign-button.bold"));
                    Anladim.Click(); 
                    elementFound = true;
                }
                catch (NoSuchElementException)
                {
                    // Handle the exception (e.g., wait for a moment, retry, etc.)
                    Console.WriteLine("Element not found. Retrying...");
                    // You can add additional code here to wait or perform other actions between retries

                }
            }

           

           


            //Beden Seç 
            IWebElement BedenSec = driver.FindElement(By.XPath("//div[@class='sp-itm' and text()='XL']"));
            BedenSec.Click();



            // "Sepete Ekle" butonunu bulmak için XPath veya CSS seçici kullanabilirsiniz
            IWebElement sepeteEkleButton = driver.FindElement(By.CssSelector(".add-to-basket"));
            

            sepeteEkleButton.Click();

            

            // <div> elementine tıklama işlemi
           

            IWebElement sepetimLink = driver.FindElement(By.CssSelector("a.link.account-basket"));
            sepetimLink.Click();


            //////////////
            ///
            IWebElement girisYapLink = driver.FindElement(By.CssSelector("a.ty-font-sm.ty-font-w-semi-bold.ty-link-button.ty-transition.ty-primary.ty-input-small"));
            girisYapLink.Click();


            IWebElement ka = driver.FindElement(By.Id("login-email"));
            IWebElement ka1 = driver.FindElement(By.Id("login-password-input"));


            ka.SendKeys("Email@hotmail.com");

            ka1.SendKeys("Pasword133133133");

            // Oturum açma düğmesi ID'sini kullanarak bulunur


            IWebElement loginButton = driver.FindElement(By.CssSelector("button.q-primary.q-fluid.q-button-medium.q-button.submit")); // Oturum açma düğmesi ID'sini kullanarak bulunur

            loginButton.Click();

             elementFound = false;
            while (!elementFound)
            {
                try
                {
                    IWebElement sepetiOnaylaLink = driver.FindElement(By.CssSelector("div.pb-summary-approve > a.ty-link-btn-primary"));
                    sepetiOnaylaLink.Click();
                    elementFound = true;
                }
                catch (NoSuchElementException)
                {
                    // Handle the exception (e.g., wait for a moment, retry, etc.)
                    Console.WriteLine("Element not found. Retrying...");
                    // You can add additional code here to wait or perform other actions between retries

                }
            }
            
            
            elementFound = false;
            while (!elementFound)
            {
                try
                {
                    IWebElement kaydetVeDevamEtButton = driver.FindElement(By.CssSelector("div.approve-button-wrapper > button.ty-primary-btn.ty-btn-large"));
                    kaydetVeDevamEtButton.Click();
                    elementFound = true;
                }
                catch (NoSuchElementException)
                {
                    // Handle the exception (e.g., wait for a moment, retry, etc.)
                    Console.WriteLine("Element not found. Retrying...");
                    // You can add additional code here to wait or perform other actions between retries

                }
            }
            elementFound = false;
            while (!elementFound)
            {
                try
                {
                    IWebElement tooltip = driver.FindElement(By.CssSelector("div.tooltip"));
                    tooltip.Click();
                    elementFound = true;
                }
                catch (NoSuchElementException)
                {
                    // Handle the exception (e.g., wait for a moment, retry, etc.)
                    Console.WriteLine("Element not found. Retrying...");
                    // You can add additional code here to wait or perform other actions between retries

                }
            }
            

            elementFound = false;
            while (!elementFound)
            {
                try
                {
                    IWebElement ziraatBankasiKartDiv = driver.FindElement(By.CssSelector("div.p-radio-button > span"));
                    ziraatBankasiKartDiv.Click();
                    elementFound = true;
                }
                catch (NoSuchElementException)
                {
                    // Handle the exception (e.g., wait for a moment, retry, etc.)
                    Console.WriteLine("Element not found. Retrying...");
                    // You can add additional code here to wait or perform other actions between retries

                }
            }
            elementFound = false;
            while (!elementFound)
            {
                try
                {
                    IWebElement securePaymentDiv = driver.FindElement(By.CssSelector("div.p-checkbox-text > div.optional-3d-payment-text"));
                    securePaymentDiv.Click();
                    elementFound = true;
                }
                catch (NoSuchElementException)
                {
                    // Handle the exception (e.g., wait for a moment, retry, etc.)
                    Console.WriteLine("Element not found. Retrying...");
                    // You can add additional code here to wait or perform other actions between retries

                }
            }
            elementFound = false;
            while (!elementFound)
            {
                try
                {
                    IWebElement odemeYapButton = driver.FindElement(By.CssSelector("div.approve-button-wrapper > button.ty-primary-btn.ty-btn-large"));
                    odemeYapButton.Click();
                    elementFound = true;
                }
                catch (NoSuchElementException)
                {
                    // Handle the exception (e.g., wait for a moment, retry, etc.)
                    Console.WriteLine("Element not found. Retrying...");
                    // You can add additional code here to wait or perform other actions between retries

                }
            }

            int beklemeSuresiMiliSaniye = 30000;
            Thread.Sleep(beklemeSuresiMiliSaniye);
            // Verilen <iframe> elementini bulun
            IWebElement iframeElement; 
            elementFound = false;
            while (!elementFound)
            {
                try
                {
                    iframeElement = driver.FindElement(By.CssSelector("iframe"));
                    driver.SwitchTo().Frame(iframeElement);
                    elementFound = true;

                }
                catch (NoSuchElementException)
                {
                    // Handle the exception (e.g., wait for a moment, retry, etc.)
                    Console.WriteLine("Element not found. Retrying...");
                    // You can add additional code here to wait or perform other actions between retries

                }
            }

            // İframe içine geçiş yapın
            

            // "Doğrulama kodu" kutusunu bulun ve içine "111111" değerini girin
            
            elementFound = false;
            while (!elementFound)
            {
                try
                {
                    IWebElement inputElement = driver.FindElement(By.Id("code")); // "code" burada input alanının ID'sini kullanıyorum, ID'yi kendi sayfanızdaki ID ile değiştirin
                    string inputValue = "123456"; // Göndermek istediğiniz değeri burada ayarlayın
                    inputElement.Clear(); // Önce mevcut değeri temizleyin (opsiyonel)
                    inputElement.SendKeys(inputValue);
                }
                catch (NoSuchElementException)
                {
                    // Handle the exception (e.g., wait for a moment, retry, etc.)
                    Console.WriteLine("Element not found. Retrying...");
                   
                    // You can add additional code here to wait or perform other actions between retries

                }
            }
            



            driver.Quit();
        }
    }
}
