using DBTesting.DB.DataContext;
using DBTesting.DB.DBContext;
using DBTesting.DB.Models;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace DBTesting.DB.Hooks
{
    [Binding]
    public sealed class DBHooks
    {
        [BeforeFeature]
        [Scope(Tag = "DB")]
        public static void FeatureSetUp(FeatureContext featureContext)
        {
            featureContext.Add(DBLabels.MainRepository, new MainRepository());
        }

        [AfterScenario]
        [Scope(Tag = "deleteSingleEntity")]

        public static void DeleteUser(ScenarioContext scenarioContext, MainRepository repo)
        {
            repo.Repository.Delete(scenarioContext.Get<int>(DBLabels.lastUserID));
        }

        [AfterScenario]
        [Scope(Tag = "deleteMultipleEntities")]

        public static void DeleteUsers(ScenarioContext scenarioContext, MainRepository repo)
        {
            var usersForDeletion = scenarioContext.Get<List<UserEntity>>(DBLabels.usersToBeDeleted);

            repo.Repository.DeleteRange(usersForDeletion);
        }
    }
}
