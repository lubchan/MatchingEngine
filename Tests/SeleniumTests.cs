
using NUnit.Framework;
using MatchingEngine.Pages;

namespace MatchingEngine.Tests
{
    [TestFixture]
    public class SeleniumTests : BaseTests
    {
        [Test]
        public void CheckProductsSupportedListIsLoaded()
            
        {
            homePage.HoverOverModulesMenu();
            Assert.That(homePage.IsRepertoireManagementModuleSubmenuDisplayed(), Is.True, "Repertoire Management Module submenu was not displayed.");

            ManagementModulePage mgmtPage = homePage.ClickRepertoireManagementModuleMenu();
            mgmtPage.scrollToAdditionalFeaturesSection();
            mgmtPage.ClickProductsSupportedLink();
            Assert.That(mgmtPage.isAdditionalFeaturesHeaderDisplayed(), Is.True, "Additional Fetures not loaded.");
            
            mgmtPage.ClickProductsSupportedLink();
            mgmtPage.waitForProductsSupportedListToBeLoaded();
            
            List<String> listOfProducts = mgmtPage.getListOfProductsSupported();
            Assert.That(listOfProducts.Count, Is.EqualTo(4), "Number of product listed does not match.");
            Assert.That(listOfProducts, Contains.Item("Recording"), "List does not contain 'Recording' product.");
            Assert.That(listOfProducts, Contains.Item("Bundle"), "List does not contain 'Bundle' product.");
            Assert.That(listOfProducts, Contains.Item("Advertisement "), "List does not contain 'Advertisement' product.");
        }
    }
}
