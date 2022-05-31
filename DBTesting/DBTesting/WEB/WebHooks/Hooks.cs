using DBTesting.WEB.WebContext;
using TechTalk.SpecFlow;

namespace DBTesting.WEB.WebHooks
{
    internal sealed class Hooks
    {
        [BeforeScenario("web")]
        private void FirstBeforeScenario()
        {
            WebDriverProvider.InitChromeDriver();
        }

        [AfterScenario("web")]
        private void AfterScenario()
        {
            WebDriverProvider.GetChromeDriver().Dispose();
        }
    }
}
