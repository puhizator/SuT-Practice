using DBTesting.WEB.Actions;
using DBTesting.WEB.WebContext;
using DBTesting.WEB.WebPages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DBTesting.WEB.StepDefinitions
{
    [Binding]
    internal class HomeStepDefinitions
    {
        private BaseUserActions _webUser;

        internal HomeStepDefinitions()
        {
            _webUser = new BaseUserActions(); 
        }

        [Then(@"I should see Welcome user message")]
        public void ThenIShouldSeeWelcomeUserMessage()
        {
            var welcomeMessage = _webUser.Find(HomePage.WELCOME_MESSAGE);
            var navBar = _webUser.Find(HomePage.NAVBAR_HEADER);
            var navBarButtons = _webUser.Find(HomePage.WELCOME_MESSAGE);

            Assert.Multiple(() =>
            {
                Assert.That(welcomeMessage.Displayed);
                Assert.AreEqual(WebLabels.NavBarHeader, navBar.Text);
                Assert.That(navBarButtons.Displayed);
            });
        }
    }
}
