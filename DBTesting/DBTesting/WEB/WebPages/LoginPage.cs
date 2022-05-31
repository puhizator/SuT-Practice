using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTesting.WEB.WebPages
{
    internal class LoginPage
    {
        public static readonly By EMAIL = By.Id(""/*Some text locator*/);

        public static readonly By PASSWORD = By.CssSelector(""/*Some text locator*/);

        public static readonly By LOGIN_BUTTON = By.CssSelector(""/*Some text locator*/);
    }
}
