using OpenQA.Selenium;

namespace DBTesting.WEB.WebPages
{
    internal class HomePage
    {
        public static readonly By WELCOME_MESSAGE = By.ClassName("jumbotron");

        public static readonly By NAVBAR_HEADER = By.XPath("//div[@class='navbar-header']");

        public static readonly By NAVBAR_BUTTONS = By.XPath("//ul[@class='nav navbar-nav']");
    }
}
