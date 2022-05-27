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
            var response = _baseRestClient.GetAllUsers();

            _scenarioContext.Add("response", response);
        }

        [When(@"I perform get request to user with id (.*)")]
        public void WhenIPerformGetRequestToUserId(int id)
        {
            var response = _baseRestClient.GetSingleUser(id);

            _scenarioContext.Add("response", response);
            _scenarioContext.Add("userEmail", response.Data.Email);
        }

        [Then(@"I should receive response code (.*) with message '(.*)'")]
        public void ThenIShouldReceiveResponseCodeWithMessage(int code, string msg)
        {
            var responseFromGetRequest = _scenarioContext.Get<RestResponse>("response");

            Assert.Multiple(() =>
            {
                Assert.That(code, Is.EqualTo((int)responseFromGetRequest.StatusCode));
                Assert.That(msg, Is.EqualTo(responseFromGetRequest.StatusDescription));
            });
        }

        [Then(@"I should see user email '(.*)'")]
        public void ThenIShouldSeeUserEmail(string email)
        {
            var emailFromResponse = _scenarioContext.Get<string>("userEmail");
            Assert.AreEqual(email, emailFromResponse, "Email from the response does not match input email");
        }
    }
}
