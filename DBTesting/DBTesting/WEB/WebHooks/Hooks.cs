using DBTesting.WEB.WebContext;
using TechTalk.SpecFlow;

namespace DBTesting.WEB.WebHooks
{
    [Binding]
    internal sealed class Hooks
    {
        [BeforeScenario]
        [Scope(Tag = "web")]
        private void FirstBeforeScenario()
        {
            WebDriverProvider.InitChromeDriver();
        }

        [AfterScenario]
        [Scope(Tag = "web")]
        private void AfterScenario()
        {
            WebDriverProvider.GetChromeDriver().Dispose();
        }
    }
}
