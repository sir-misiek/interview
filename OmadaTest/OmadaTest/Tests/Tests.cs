using NUnit.Framework;
using OmadaTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OmadaTest
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private Utils utils = new Utils();

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Users\sirmi\source\repos\OmadaTest\");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void CheckIfOmadaIdentityCloudIsLoadedFromTopMenu()
        {
            HomePage homePage = new HomePage(driver);
            Products products;
            homePage.GoToOmadaHomePage();
            products = homePage.SelectOmadaIdentityCLoudFromTopMenu();
            Assert.AreEqual("Omada Identity Cloud", products.GetOmadaIdentityCloudTitle());
            Assert.AreEqual(products.GetOmadaIdentityCloudUrl(), driver.Url);
        }

        [Test]
        public void CheckIfOmadaIdentityCloudIsLoadedFromFooterMenu()
        {
            HomePage homePage = new HomePage(driver);
            Products products;
            homePage.GoToOmadaHomePage();
            products = homePage.SelectOmadaIdentityCloudFromFooterMenu();
            Assert.AreEqual("Omada Identity Cloud", products.GetOmadaIdentityCloudTitle());
            Assert.AreEqual(products.GetOmadaIdentityCloudUrl(), driver.Url);
        }

        [Test]
        public void CheckIfSearchOurJobsOpeningsRedirectsToExternalPage()
        {
            HomePage homePage = new HomePage(driver);
            Careers careers;
            homePage.GoToOmadaHomePage();
            careers = homePage.SelectCarrersFromTopMenu();
            Assert.AreEqual(careers.GetCareersUrl(), driver.Url);
            careers.ClickSearchOurJobOpeningsButton();
            utils.WaitForPageIsLoaded(driver);
            Assert.AreNotEqual(careers.GetCareersUrl(), driver.Url);
        }

        [Test]
        public void CheckIfOpenJobsPositionsRedirectsToExternalPage()
        {
            HomePage homePage = new HomePage(driver);
            Careers careers;
            homePage.GoToOmadaHomePage();
            careers = homePage.SelectCarrersFromTopMenu();
            Assert.AreEqual(careers.GetCareersUrl(), driver.Url);
            careers.ClickOpenJobPositionsButton();
            utils.SwitchToTab(driver, 1);
            utils.WaitForPageIsLoaded(driver);
            Assert.AreNotEqual(careers.GetCareersUrl(), driver.Url);
        }
    }
}
