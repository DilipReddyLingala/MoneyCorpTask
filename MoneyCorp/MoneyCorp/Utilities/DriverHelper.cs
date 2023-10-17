using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCorp.Utilities
{
    public class DriverHelper
    {
       public static IWebDriver driver;
        public static WebDriverWait wait;
        public static void InitializeBrowser() {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.moneycorp.com/en-gb/");
            driver.Manage().Window.Maximize();
            var actualResult = DriverHelper.driver.Url.ToString();
            var expectedResult = "https://www.moneycorp.com/en-gb/";
            if (actualResult.Contains(expectedResult))
            {
                Console.WriteLine("Verified Application Launched Successfully with given URL");
            }
            else
            {
                Console.WriteLine("Not Verified Application Not Launched Successfully with given URL");
            }
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(60);
            wait=new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            driver.FindElement(By.XPath("//button[text()='Accept All Cookies']")).Click();
        }
        
      
    }
}
