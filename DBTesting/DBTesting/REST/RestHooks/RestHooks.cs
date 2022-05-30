using DBTesting.REST.RestContext;
using DBTesting.REST.Utils;
using TechTalk.SpecFlow;

namespace DBTesting.REST.RestHooks
{
    [Binding]
    internal sealed class RestHooks
    {

        [AfterScenario]
        [Scope(Tag = "deleteSingleUser")]

        public static void DeleteUser(ScenarioContext scenarioContext, BaseRestClient baseRestClient)
        {
            var idToDelete = scenarioContext.Get<int>(RestLabels.lastCreatedUserID);

            baseRestClient.DeleteSingleUser(idToDelete);
        }
    }
}
