using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OmadaTest.Pages
{
    class Products
    {
        public IWebDriver driver { get; set; }
        private string omadaIdentityCloudUrl = "https://omadaidentity.com/products/omada-identity-cloud/";

        public Products(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h1[class='h1 title']")]
        public IWebElement omadaIdentityCloudTitle;

        public string GetOmadaIdentityCloudUrl()
        {
            return omadaIdentityCloudUrl;
        }

        public string GetOmadaIdentityCloudTitle()
        {
            return omadaIdentityCloudTitle.Text;
        }
    }
}
