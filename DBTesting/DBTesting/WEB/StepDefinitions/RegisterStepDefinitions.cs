using DBTesting.Configurations;
using DBTesting.Helpers;
using DBTesting.WEB.Actions;
using DBTesting.WEB.Models;
using DBTesting.WEB.WebContext;
using DBTesting.WEB.WebPages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DBTesting.WEB.StepDefinitions
{
    [Binding]
    public class RegisterStepDefinitions
    {
        private BaseUserActions _webUser;

        internal RegisterStepDefinitions()
        {
            _webUser = new BaseUserActions();
        }

        [Given(@"I navigate to registration page")]
        public void GivenINavigateToRegistrationPage()
        {
            _webUser.OpenPage(ConfigurationProvider.GetValue[ConfigurationLabels.RegisterBaseUrl]);
        }

        [When(@"I enter the following data for registration:")]
        public void WhenIEnterTheFollowingDataForRegistration(Table table)
        {
            User currentUser = table.CreateInstance<User>();
            if (currentUser.Email == WebLabels.GetRandomEmail)
            {
                currentUser.Email = Helper.GetRandomEmail();
            }

            _webUser.TypesInto(RegisterPage.FIRSTNAME, currentUser.FirstName);
            _webUser.TypesInto(RegisterPage.SIRNAME, currentUser.SirName);
            _webUser.TypesInto(RegisterPage.EMAIL, currentUser.Email);
            _webUser.TypesInto(RegisterPage.PASSWORD, currentUser.Password);
            _webUser.TypesInto(RegisterPage.COUNTRY, currentUser.Country);
            _webUser.TypesInto(RegisterPage.CITY, currentUser.City);
        }

        [When(@"I check agreement")]
        public void WhenICheckAgreement()
        {
            _webUser.ClicksOn(RegisterPage.CHECKBOX);
        }

        [When(@"I click on register button")]
        public void WhenIClickOnRegisterButton()
        {
            _webUser.ClicksOn(RegisterPage.REGISTER_BUTTON);
        }

        [Then(@"I should see error message for existing user")]
        public void ThenIShouldSeeErrorMessageForExistingUser()
        {
            var errorMessage = _webUser.Find(RegisterPage.EXISTING_USER_MESSAGE);

            Assert.AreEqual(WebLabels.ExistingUserExpectedMessage, errorMessage.Text);
        }
    }
}
