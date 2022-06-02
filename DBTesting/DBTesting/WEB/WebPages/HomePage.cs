using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DBTesting.WEB.WebPages
{
    internal class HomePage
    {
        public static readonly By WELCOME_MESSAGE = By.XPath("//h1");

        public static readonly By NAVBAR_HEADER = By.XPath("//div[@class='navbar-header']");
        
        public static readonly By NAVBAR_BUTTONS = By.XPath("//ul[@class='nav navbar-nav']");
    }
}
