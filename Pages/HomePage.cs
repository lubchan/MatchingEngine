using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MatchingEngine.Pages
{
    public class HomePage
    {
        private WebDriver driver; 
        private By modulesMenu = By.CssSelector("#navMenu a[class='navbar-link is-active']");
        private By managementModuleButton = By.CssSelector("#navMenu a[href='https://www.matchingengine.com/repertoire-management-module/']"); 

        public HomePage(WebDriver driver)
        {
            this.driver = driver;
        }

        public void HoverOverModulesMenu()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(modulesMenu)).Perform();
        }

        public Boolean IsRepertoireManagementModuleSubmenuDisplayed()
        {
            return driver.FindElement(managementModuleButton).Displayed;
        }
        public ManagementModulePage ClickRepertoireManagementModuleMenu()
        {
            driver.FindElement(managementModuleButton).Click();
            return new ManagementModulePage(driver);
        }

    }
}
