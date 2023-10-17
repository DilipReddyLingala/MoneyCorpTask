using MoneyCorp.PageObjects;
using MoneyCorp.Utilities;

namespace MoneyCorp
{
    public class Tests
    {
        HomePage objHome= new HomePage();
        
        [SetUp]
        public void Init()
        {
            DriverHelper.InitializeBrowser();

           
        }

        [Test]
        public void ValidateArticleLinks()
        {
            objHome.ClickOnCountrySymbol();
            objHome.SelectcountryUsa();
            objHome.ClickonFindOutForForeign();
            objHome.searchWords("international payments");
            objHome.VerifyAllArticals();
        }
        [TearDown] public void TearDown()
        {
            DriverHelper.driver.Quit();
        }
    }
}