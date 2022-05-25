using DBTesting.REST.Models;
using DBTesting.REST.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DBTesting.REST.StepDefinitions
{
    [Binding]
    public class GetRequestsStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private BaseRestClient _baseRestClient;

        public GetRequestsStepDefinitions(ScenarioContext scenarioContext)
        {
            _baseRestClient = new BaseRestClient();
            _scenarioContext = scenarioContext;
        }

        [When(@"I perform get request to all users")]
        public void WhenIPerformGetRequestToAllUsers()
        {
            _baseRestClient.GetAllUsers();
        }

        [When(@"I perform get request to user with id (.*)")]
        public void WhenIPerformGetRequestToUserId(int id)
        {
            _baseRestClient.GetSingleUser(id);

            var user = _baseRestClient.ResponseContent;

            var deseralizedUser = JsonConvert.DeserializeObject<User>(user);

            _scenarioContext.Add("userEmail", deseralizedUser.Email);

        }

        [Then(@"I should receive response code (.*) with message ""([^""]*)""")]
        public void ThenIShouldReceiveResponseCodeWithMessage(int code, string msg)
        {
            Assert.Multiple(() =>
            {
                Assert.That(code, Is.EqualTo(_baseRestClient.ResponseCode));
                Assert.That(msg, Is.EqualTo(_baseRestClient.ResponseMessage));
            });
        }


        [Then(@"I should see user email ""([^""]*)""")]
        public void ThenIShouldSeeUserEmail(string email)
        {
            Assert.AreEqual(email, _scenarioContext.Get<string>("userEmail"), "Email does not match");
        }


    }
}
