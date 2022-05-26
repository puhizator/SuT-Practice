using DBTesting.REST.Models;
using DBTesting.REST.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
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
            var users = _baseRestClient.GetAllUsers();

            List<User> trueUsers = users.Data;
        }

        [When(@"I perform get request to user with id (.*)")]
        public void WhenIPerformGetRequestToUserId(int id)
        {
            var response = _baseRestClient.GetSingleUser(id);

            _scenarioContext.Add("response", response);

        }

        [Then(@"I should receive response code (.*) with message ""([^""]*)""")]
        public void ThenIShouldReceiveResponseCodeWithMessage(int code, string msg)
        {
            Assert.Multiple(() =>
            {
                var responseFromGetRequest = _scenarioContext.Get<RestResponse<User>>("response");

                Assert.That(code, Is.EqualTo(responseFromGetRequest.StatusCode));
                Assert.That(msg, Is.EqualTo(responseFromGetRequest.StatusDescription));
            });
        }


        [Then(@"I should see user email ""([^""]*)""")]
        public void ThenIShouldSeeUserEmail(string email)
        {
            Assert.AreEqual(email, _scenarioContext.Get<string>("userEmail"), "Email does not match");
        }


    }
}
