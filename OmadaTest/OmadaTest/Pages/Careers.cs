using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmadaTest.Pages
{
    class Careers
    {
        public IWebDriver driver { get; set; }
        private Utils utils = new Utils();
        private string careersUrl = "https://omadaidentity.com/company/careers/";

        public Careers(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Search our job openings']/ancestor::a")]
        public IWebElement searchOurJobOpeningsButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Open job positions']/ancestor::a")]
        public IWebElement openJobPositionsButton;

        public string GetCareersUrl()
        {
            return careersUrl;
        }

        public void ClickSearchOurJobOpeningsButton()
        {
            utils.WaitForPageElementToBeClickable(driver, searchOurJobOpeningsButton);
            searchOurJobOpeningsButton.Click();
        }

        public void ClickOpenJobPositionsButton()
        {
            utils.WaitForPageElementToBeClickable(driver, openJobPositionsButton);
            openJobPositionsButton.Click();
        }
    }
}
