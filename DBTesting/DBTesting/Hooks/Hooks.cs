using DBTesting.DataContext;
using DBTesting.Models;
using TechTalk.SpecFlow;

namespace DBTesting.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private static MainRepository _repo;

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
            _repo = repo;

            _repo.Repository.Delete(scenarioContext.Get<int>("lastUserID"));
        }
    }
}
