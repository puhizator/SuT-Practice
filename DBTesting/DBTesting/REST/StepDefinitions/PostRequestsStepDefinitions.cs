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
            var user = _baseRestClient.PostSingleUser(TestData.DefaultUser());
            var name = user.Data.FirstName;
            var code = user.StatusCode;

        }

        [Then(@"I should see succesfully created user")]
        public void ThenIShouldSeeSuccesfullyCreatedUser()
        {
            //throw new PendingStepException();
        }
    }
}
