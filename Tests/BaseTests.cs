using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using MatchingEngine.Pages;

namespace MatchingEngine.Tests
{
    public class BaseTests
    {
        private WebDriver driver;
        protected HomePage homePage;
        

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://matchingengine.com/");
            homePage = new HomePage(driver);
            driver.Manage().Window.Maximize();
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        
     }
}
