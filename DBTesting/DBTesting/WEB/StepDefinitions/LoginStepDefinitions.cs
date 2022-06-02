using DBTesting.WEB.WebPages;
using DBTesting.WEB.Actions;
using TechTalk.SpecFlow;
using DBTesting.Configurations;
using NUnit.Framework;
using DBTesting.WEB.WebContext;

namespace DBTesting.WEB.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private BaseUserActions _webUser;

        internal LoginStepDefinitions()
        {
            _webUser = new BaseUserActions();    
        }

        [Given(@"I navigate to login page")]
        public void GivenINavigateToLoginPage()
        {
            _webUser.OpenPage(ConfigurationProvider.GetValue[ConfigurationLabels.BaseUrl]);
        }

        [When(@"I enter username '(.*)' and password '(.*)'")]
        public void WhenIEnterUsernameAndPassword(string email, string password)
        {
            _webUser.TypesInto(LoginPage.EMAIL, email);
            _webUser.TypesInto(LoginPage.PASSWORD, password);
        }

        [When(@"I click on login button")]
        public void WhenIClickOnLoginButton()
        {
            _webUser.ClicksOn(LoginPage.LOGIN_BUTTON);
        }

        [Then(@"I should see error message")]
        public void ThenIShouldSeeErrorMessage()
        {
            var errorMessage = _webUser.Find(LoginPage.INVALID_USER_MESSAGE);

            Assert.AreEqual(WebLabels.InvalidUserExpectedMessage, errorMessage.Text);
        }

    }
}
