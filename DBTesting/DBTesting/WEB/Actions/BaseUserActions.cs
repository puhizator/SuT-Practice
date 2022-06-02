using DBTesting.Configurations;
using DBTesting.WEB.WebContext;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DBTesting.WEB.Actions
{
    internal class BaseUserActions
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public BaseUserActions()
        {
            _driver = WebDriverProvider.GetChromeDriver();
        }

        internal void OpenPage(string pageName)
        {
            _driver.Navigate().GoToUrl(pageName);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(int.Parse(ConfigurationProvider.GetValue[ConfigurationLabels.DefaultImplicitTimeout])));
        }

        internal void TypesInto(By elementLocator, string text)
        {
            WaitsUntilClicable(elementLocator).Clear();
            Find(elementLocator).SendKeys(text);
        }

        internal void ClicksOn(By elementLocator)
        {
            WaitsUntilClicable(elementLocator).Click(); 
        }

        internal string ReadsTextFrom(By elementLocator)
        {
            return WaitsUntilVisible(elementLocator).Text.Trim();
        }
        internal IWebElement Find(By elementLocator)
        {
            return _driver.FindElement(elementLocator);
        }
        internal IWebElement WaitsUntilClicable(By elementLocator)
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
        }

        internal IWebElement WaitsUntilVisible(By elementLocator)
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
        }
    }
}
