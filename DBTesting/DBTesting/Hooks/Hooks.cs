using DBTesting.DataContext;
using DBTesting.Models;
using System.Collections.Generic;
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
        [Scope(Tag = "deleteSingleEntity")]

        public static void DeleteUser(ScenarioContext scenarioContext, MainRepository repo)
        {
            repo.Repository.Delete(scenarioContext.Get<int>("lastUserID"));
        }

        [AfterScenario]
        [Scope(Tag = "deleteMultipleEntities")]

        public static void DeleteUsers(ScenarioContext scenarioContext, MainRepository repo)
        {
            var usersForDeletion = scenarioContext.Get<List<UserEntity>>("usersToBeDeleted");

            repo.Repository.DeleteRange(usersForDeletion);
        }
    }
}
