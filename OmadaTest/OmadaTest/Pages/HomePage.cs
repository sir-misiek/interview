using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OmadaTest.Pages
{
    class HomePage
    {
        private string url = "https://omadaidentity.com/";

        public IWebDriver driver { get; set; }
        private Utils utils = new Utils();
        private const string topMenuLocator = "header-menu";

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = topMenuLocator)]
        public IWebElement topMenu;

        [FindsBy(How = How.XPath, Using = "//a[text()='Products']")]
        public IWebElement productsTopMenuItem;

        [FindsBy(How = How.XPath, Using = "//a[text()='Company']")]
        public IWebElement companyTopMenuItem;

        [FindsBy(How = How.XPath, Using = "//*[@class='menu-links']//a[text()='Omada Identity Cloud']")]
        public IWebElement omadaIdentityCloudMenuItem;

        [FindsBy(How = How.XPath, Using = "//*[@class='menu-links']//a[text()='Careers']")]
        public IWebElement careerssMenuItem;

        [FindsBy(How = How.XPath, Using = "//footer//a[text()='Omada Identity Cloud']")]
        public IWebElement omadaIdentityCloudFooterItem;

        public void GoToOmadaHomePage()
        {
            driver.Navigate().GoToUrl(url);
        }

        public Products SelectOmadaIdentityCLoudFromTopMenu()
        {
            utils.WaitForPageElementToBeVisible(driver, By.Id(topMenuLocator));
            utils.HoverOverTopMenuItem(driver, productsTopMenuItem);
            utils.ClickOnMenuItem(driver, omadaIdentityCloudMenuItem);
            return new Products(driver);
        }

        public Products SelectOmadaIdentityCloudFromFooterMenu()
        {
            utils.WaitForPageElementToBeClickable(driver, omadaIdentityCloudFooterItem);
            omadaIdentityCloudFooterItem.Click();
            return new Products(driver);
        }

        public Careers SelectCarrersFromTopMenu()
        {
            utils.WaitForPageElementToBeVisible(driver, By.Id(topMenuLocator));
            utils.HoverOverTopMenuItem(driver, companyTopMenuItem);
            utils.ClickOnMenuItem(driver, careerssMenuItem);
            return new Careers(driver);
        }
    }
}
