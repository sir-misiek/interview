using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace OmadaTest
{
    class Utils
    {
        public const int defaultTimeout = 10;
        public void WaitForPageElementToBeClickable(IWebDriver driver, IWebElement element, int timeout = defaultTimeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForPageElementToBeVisible(IWebDriver driver, By by, int timeout = defaultTimeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public void HoverOverTopMenuItem(IWebDriver driver, IWebElement topMenuItem)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(topMenuItem);
            actions.Build().Perform();
        }

        public void ClickOnMenuItem(IWebDriver driver, IWebElement element)
        {
            WaitForPageElementToBeClickable(driver, element);
            element.Click();
        }

        public void WaitForPageIsLoaded(IWebDriver driver, int timeout = defaultTimeout)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void SwitchToTab(IWebDriver driver, int tab)
        {
            driver.SwitchTo().Window(driver.WindowHandles[tab]);
        }
    }
}
