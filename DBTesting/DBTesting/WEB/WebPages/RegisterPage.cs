using OpenQA.Selenium;

namespace DBTesting.WEB.WebPages
{
    internal class RegisterPage
    {
        public static readonly By FIRSTNAME = By.XPath("//input[@name='first_name']");

        public static readonly By SIRNAME = By.XPath("//input[@name='sir_name']");

        public static readonly By EMAIL = By.XPath("//input[@name='email']");

        public static readonly By PASSWORD = By.XPath("//input[@name='pass']");

        public static readonly By COUNTRY = By.XPath("//input[@name='country']");

        public static readonly By CITY = By.XPath("//input[@name='city']");

        public static readonly By CHECKBOX = By.XPath("//input[@id='TOS']");

        public static readonly By REGISTER_BUTTON = By.XPath("//button[@id='reg']");

        public static readonly By EXISTING_USER_MESSAGE = By.XPath("//div[@class='alert alert-warning']");
    }
}
