using DBTesting.DataContext;
using TechTalk.SpecFlow;

namespace DBTesting.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeFeature]
        [Scope(Tag = "DB")]
        public static void FeatureSetUp(FeatureContext featureContext)
        {
            featureContext.Add(DBContext.Labels.MainRepository, new MainRepository());
        }

        [AfterScenario]
        [Scope(Tag = "deleteEntity")]

        public static void DeleteUser(ScenarioContext scenarioContext, MainRepository repo)
        {
            repo.Repository.Delete(scenarioContext.Get<int>("lastUserID"));
        }
    }
}
