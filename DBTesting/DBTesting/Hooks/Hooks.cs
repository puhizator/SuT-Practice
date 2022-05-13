using DBTesting.DataContext;
using TechTalk.SpecFlow;

namespace DBTesting.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario("DB")]

        public static void FeatureSetUp(FeatureContext featureContext)
        {
            featureContext.Add(DBContext.Labels.MainRepository, new MainRepository());
        }
    }
}
