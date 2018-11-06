using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitesParser.BL.Interfaces;
using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SitesParser.BL.Services
{
    public class ZolotoyvekParser : IParser
    {
        public event EventHandler<ShopFoundEventArgs> OnShopFound;

        public List<string> FindShops(string url)
        {
            List<string> result = new List<string>();
            IWebDriver driver;
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
            // options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            //System.Threading.Thread.Sleep(2000);
            //sel - cities
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("return document.getElementById('sel-cities').style.display = 'block';");

            var mySelectElement = driver.FindElement(By.Id("sel-cities"));
            var dropdown = new SelectElement(mySelectElement);

            for (var i = 0; i < dropdown.Options.Count; i++)
            {
                dropdown.SelectByIndex(i);
                //var selectedItemText = (string)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].options[arguments[0].selectedIndex].text;", dropdown);
                //SaveResult(selectedItemText);

                ReadOnlyCollection<IWebElement> shops = driver.FindElements(By.XPath("//ul[@id='addressList']/li"));
                foreach (IWebElement shop in shops)
                {
                    OnShopFound?.Invoke(this, new ShopFoundEventArgs(result.Count, shop.Text));
                    result.Add(shop.Text);
                }
            }

            //IWebelement link = m_driver.FindElement(By.XPath(".//*[@id='rt-header']//div[2]/div/ul/li[2]/a"));
            //link.Click();
            driver.Close();
            return result;
        }
    }
}
