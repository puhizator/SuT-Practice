using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Framework;

namespace DBTesting.WEB.WebContext
{
    internal class WebDriverProvider
    {
        private static IWebDriver _driver;

        [SetUp]
        internal static void InitChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("incognito");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        internal static IWebDriver GetChromeDriver()
        {
            return _driver;
        }
    }
}
