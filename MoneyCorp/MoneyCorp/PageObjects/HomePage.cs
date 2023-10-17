using Docker.DotNet.Models;
using MoneyCorp.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoneyCorp.PageObjects
{
    public class HomePage
    {
        By countrysymbol = By.Id("language-dropdown-flag");
        By SelectUsa = By.XPath("//a[@aria-label=\"USA English\"]");
        By SelectFindOutForForeignMove = By.XPath("//h3[text()='Foreign exchange solutions']/../p");
        By SelectFindOutForForeign = By.XPath("//h3[text()='Foreign exchange solutions']/../a/span");
        By SearchButton = By.XPath("//div[@class=\"c-header__wrap\"]/div[3]//input[@id='nav_search']");
        By SearchBtnClick = By.XPath("//div[@class=\"c-header__wrap\"]/div[3]//input[@type='submit']");


        public void ClickOnCountrySymbol()
        {
            DriverHelper.driver.FindElement(countrysymbol).Click();
        }
       
        public void SelectcountryUsa()
        {
            DriverHelper.driver.FindElement(SelectUsa).Click();
            var actualResult=DriverHelper.driver.Url.ToString();
            var expectedResult = "https://www.moneycorp.com/en-us/";
            Assert.That(expectedResult, Is.EqualTo(actualResult),"Verified that Application is landed to USA page");
            Console.WriteLine("Verified that Application is landed to USA page");
        }

        public void ClickonFindOutForForeign() {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverHelper.driver;
            js.ExecuteScript("window.scrollBy(0,250)", "");
            DriverHelper.driver.FindElement(SelectFindOutForForeign).Click();
            var actualResult = DriverHelper.driver.Url.ToString();
            var expectedResult = "https://www.moneycorp.com/en-us/business/foreign-exchange-solutions/";
            Assert.That(expectedResult, Is.EqualTo(actualResult), "Verified that Application is landed to Foreign Exchange Solutions page");
            Console.WriteLine("Verified that Application is landed to Foreign Exchange Solutions page");

        }

        public void searchWords(String data) {
            DriverHelper.driver.FindElement(SearchButton).Click();
            DriverHelper.driver.FindElement(SearchButton).SendKeys(data);
            DriverHelper.driver.FindElement(SearchBtnClick).Click();
            By locater = By.XPath("//input[@value='"+data+"']");
            DriverHelper.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locater));
            var actualResult = DriverHelper.driver.FindElement(locater).GetAttribute("value");
            Console.WriteLine(actualResult);
            if (actualResult.Contains(data))
            {
                Console.WriteLine("Verified that Application is landed to " + data);
            }
            else {
                Console.WriteLine("Not Verified that Application is landed to " + data);
            }
            
        }

        public void VerifyAllArticals() {

            By Xpath = By.XPath("//div[@class='results-wrapper']/div//a");
            var allWindowCount=DriverHelper.driver.FindElements(Xpath).Count;
            for(int i = 1; i < allWindowCount; i++)
            {
                DriverHelper.driver.FindElement(By.XPath("//div[@class='results-wrapper']/div[" + i + "]//a")).Click();
                Thread.Sleep(2000);
                var actualResult = DriverHelper.driver.Url.ToString();
                var expectedResult = "https://www.moneycorp.com/en-us";
                if(actualResult.Contains(expectedResult))
                {
                    Console.WriteLine("Verified that Application link that starts with https://www.moneycorp.com/en-us/");
                }
                else
                {
                    Console.WriteLine("Not Verified that Application link that starts with https://www.moneycorp.com/en-us/");
                }
                DriverHelper.driver.Navigate().Back();
                Thread.Sleep(2000);
            }

        }
    }
}
