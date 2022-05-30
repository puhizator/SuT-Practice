using System;
using DBTesting.REST.Models;
using DBTesting.REST.RestContext;
using DBTesting.REST.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DBTesting.REST.StepDefinitions
{
    [Binding]
    public class PutRequestsStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private BaseRestClient _baseRestClient;

        public PutRequestsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _baseRestClient = new BaseRestClient();
        }

        [Given(@"I have existing user")]
        public void GivenIHaveExistingUser(Table table)
        {
            var user = table.CreateInstance<User>();
            var response = _baseRestClient.PostSingleUser(user);

            _scenarioContext.Add(RestLabels.lastCreatedUser, response.Data);
            _scenarioContext.Add(RestLabels.lastCreatedUserID, response.Data.Id);
        }

        [When(@"I execute PUT request with the following user")]
        public void WhenIExecutePUTRequestWithTheFollowingUser(Table table)
        {
            User user = table.CreateInstance<User>();
            var lastUpdatedUserID = _scenarioContext.Get<int>(RestLabels.lastCreatedUserID);
            var response = _baseRestClient.UpdateSingleUser(lastUpdatedUserID, user);

            _scenarioContext.Add(RestLabels.lastUpdatedUser, response.Data);
            _scenarioContext.Add(RestLabels.lastUpdatedUserID, response.Data.Id);
        }

        [Then(@"I should see succesfully updated user")]
        public void ThenIShouldSeeSuccesfullyUpdatedUser()
        {
            var lastUpdatedUser = _scenarioContext.Get<User>(RestLabels.lastUpdatedUser);
            var returnedUpdatedUser = _baseRestClient.GetSingleUser(lastUpdatedUser.Id).Data;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(lastUpdatedUser.FirstName, returnedUpdatedUser.FirstName, "First name has not been updated");
                Assert.AreEqual(lastUpdatedUser.SirName, returnedUpdatedUser.SirName, "Sir name has not been updated");
                Assert.AreEqual(lastUpdatedUser.Country, returnedUpdatedUser.Country, "Country has not been updated");
                Assert.AreEqual(lastUpdatedUser.City, returnedUpdatedUser.City, "City has not been updated");
                Assert.AreEqual(lastUpdatedUser.Title, returnedUpdatedUser.Title, "Title has not been updated");
                Assert.AreEqual(lastUpdatedUser.Email, returnedUpdatedUser.Email, "Email has not been updated");
            });
        }
    }
}
