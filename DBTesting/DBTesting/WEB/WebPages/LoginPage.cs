using OpenQA.Selenium;

namespace DBTesting.WEB.WebPages
{
    internal class LoginPage
    {
        public static readonly By EMAIL = By.XPath("//input[@name='email']");

        public static readonly By PASSWORD = By.XPath("//input[@name='pass']");

        public static readonly By LOGIN_BUTTON = By.XPath("//button[@name='btn-login']");

        public static readonly By INVALID_USER_MESSAGE = By.XPath("//div[@class='alert alert-danger']");
    }
}
