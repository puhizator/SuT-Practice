using DBTesting.REST.Models;
using DBTesting.REST.Utils;
using Newtonsoft.Json;
using System;
using TechTalk.SpecFlow;

namespace DBTesting.REST.StepDefinitions
{
    [Binding]
    public class PostRequestsStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private BaseRestClient _baseRestClient;

        public PostRequestsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _baseRestClient = new BaseRestClient();
        }

        [When(@"I execute POST request with default user")]
        public void WhenIExecutePOSTRequestWithDefaultUser()
        {
            _baseRestClient.PostSingleUser(TestData.DefaultUser());

            var user = JsonConvert.DeserializeObject<User>(_baseRestClient.ResponseContent);
        }

        [Then(@"I should see succesfully created user")]
        public void ThenIShouldSeeSuccesfullyCreatedUser()
        {
            throw new PendingStepException();
        }
    }
}
