using DBTesting.REST.Models;
using DBTesting.REST.RestContext;
using DBTesting.REST.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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

        [When(@"I execute POST request with new test user")]
        public void WhenIExecutePOSTRequestWithDefaultUser()
        {
            var response = _baseRestClient.PostSingleUser(TestData.GetNewUser());

            _scenarioContext.Add(RestLabels.lastCreatedUser, response.Data);
            _scenarioContext.Add(RestLabels.lastCreatedUserID, response.Data.Id);
        }

        [When(@"I execute POST request with the following user")]
        public void WhenIExecutePOSTRequestWithTheFollowingUser(Table table)
        {
            User user = table.CreateInstance<User>();
            var response = _baseRestClient.PostSingleUser(user);

            _scenarioContext.Add(RestLabels.lastCreatedUser, response.Data);
            _scenarioContext.Add(RestLabels.lastCreatedUserID, response.Data.Id);
        }

        [Then(@"I should see succesfully created user")]
        public void ThenIShouldSeeSuccesfullyCreatedUser()
        {
            var lastCreatedUser = _scenarioContext.Get<User>(RestLabels.lastCreatedUser);
            var returnedUser = _baseRestClient.GetSingleUser(lastCreatedUser.Id).Data;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(lastCreatedUser.FirstName, returnedUser.FirstName, "First name of input user != first name of get user");
                Assert.AreEqual(lastCreatedUser.SirName, returnedUser.SirName, "Sir name of input user != sir name of get one");
                Assert.AreEqual(lastCreatedUser.Country, returnedUser.Country, "Country of input user != country of get one");
                Assert.AreEqual(lastCreatedUser.City, returnedUser.City, "City of input user != city of get one");
                Assert.AreEqual(lastCreatedUser.Title, returnedUser.Title, "Title of input user != title of get one");
                Assert.AreEqual(lastCreatedUser.Email, returnedUser.Email, "Email of input user != email of get one");
                Assert.AreEqual(lastCreatedUser.IsAdmin, returnedUser.IsAdmin, "Wrong admin rights assigned");
            });
        }
    }
}
