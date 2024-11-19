using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MatchingEngine.Pages
{
    public class ManagementModulePage
    {
        private WebDriver driver;
        private By additionalFeaturesHeader = By.XPath("//h2[contains(text(), 'Additional Features')]");
        private By productsSupportedLink = By.XPath("//ul//li//a//span[contains(text(), 'Products Supported')]");
        private By productsSupportTitle = By.XPath("//h3[contains(text(), 'There are several types of Product Supported')]");
        private By productsSupported = By.CssSelector("[class='vc_tta-panel vc_active'] [class='wpb_text_column wpb_content_element wpb_animate_when_almost_visible wpb_fadeIn fadeIn wpb_start_animation animated']");
        public ManagementModulePage(WebDriver driver)
        {
            this.driver = driver;
        }

        public void scrollToAdditionalFeaturesSection()
        {
            IWebElement additionalFeaturesElement = driver.FindElement(additionalFeaturesHeader);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", additionalFeaturesElement);

        }

        public Boolean isAdditionalFeaturesHeaderDisplayed()
        {
            return driver.FindElement(additionalFeaturesHeader).Displayed;
        }

        public void ClickProductsSupportedLink()
        {
            driver.FindElement(productsSupportedLink).Click();
        }

        public void waitForProductsSupportedListToBeLoaded()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            try
            {
                IWebElement productsSupportedTitleElement = driver.FindElement(productsSupportTitle);
                wait.Until(ExpectedConditions.ElementIsVisible(productsSupported));
            }
            catch (Exception NoSuNoSuchElementException)
            {
                throw new Exception("Product's list was not loaded");
            }
        }

        public List<String> getListOfProductsSupported()
        {
            IWebElement productsSupportedTitleElement = driver.FindElement(productsSupportTitle)
                .FindElement(By.XPath("parent::*"));
            IReadOnlyList<IWebElement> products = productsSupportedTitleElement.FindElements(By.CssSelector("ul li"));
            List<String> listOfProducts = new List<String>();
      
            foreach (IWebElement prod in products)
            {
                listOfProducts.Add(prod.Text);
            }
            return listOfProducts;
        }
    }
}
