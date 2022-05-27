using DBTesting.DB.DataContext;
using DBTesting.DB.DBContext;
using DBTesting.DB.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace DBTesting.DB.StepDefinitions
{
    [Binding]
    public class GetUsersStepDefinitions
    {
        private FeatureContext _featureContext;
        private ScenarioContext _scenarioContext;
        private MainRepository _repo;

        public GetUsersStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _repo = _featureContext.Get<MainRepository>(Labels.MainRepository);
            _scenarioContext = scenarioContext;
        }

        [When(@"Get all users")]
        public void WhenGetAllUsers()
        {
            var dbSet = _repo.Repository.GetAll();
            var count = dbSet.Count();
            _scenarioContext.Add("collectionCount", count);
        }

        [When(@"Get single user by ID (.*)")]
        public void WhenGetSingleUserByID(int id)
        {
            var user = _repo.Repository.Get(id);

            _scenarioContext.Add("userByID", user);
        }


        [When(@"Get first user")]
        public void WhenGetFirstUser()
        {
            var firstUser = _repo.Repository.GetFirst();
            _scenarioContext.Add("firstUserID", firstUser.Id);
        }

        [When(@"I Get user by email '(.*)'")]
        public void WhenIGetUserByEmail(string email)
        {
            var user = _repo.Repository.Get(e => e.Email.Equals(email)).FirstOrDefault();

            _scenarioContext.Add("returnedUserEmail", user.Email);
        }

        [When(@"Get users by email containing '(.*)'")]
        public void WhenGetUsersByEmailContaining(string phrase)
        {
            var usersIEnum = _repo.Repository.Get(entity => entity.Email.Contains(phrase));

            _scenarioContext.Add("usersContainPhrase", usersIEnum);
        }

        [Then(@"I should be able to see list of all users")]
        public void ThenIShouldBeAbleToSeeListOfAllUsers()
        {
            var collectionMembers = _scenarioContext.Get<int>("collectionCount");
            Assert.That(collectionMembers > 0);
        }

        [Then(@"I should see user with ID (.*)")]
        public void ThenIShouldSeeUserWithID(int id)
        {
            var givenUser = _scenarioContext.Get<UserEntity>("userByID");
            Assert.That(givenUser.Id, Is.EqualTo(id), "Returned ID is not correct");
        }

        [Then(@"I should see first user")]
        public void ThenIShouldSeeFirstUser()
        {
            var dbSet = _repo.Repository.GetAll();
            var firstUser = dbSet.First();
            var returnedFirstUserID = _scenarioContext.Get<int>("firstUserID");

            //TODO: think about error msg
            Assert.That(returnedFirstUserID, Is.EqualTo(firstUser.Id), "error");
        }

        [Then(@"I should see user with the same '(.*)'")]
        public void ThenIShouldSeeUserWithTheSameEmail(string email)
        {
            var returnedUserEmail = _scenarioContext.Get<string>("returnedUserEmail");

            Assert.AreEqual(returnedUserEmail, email);
        }

        [Then(@"I should see all users that contain this '(.*)' in their emails")]
        public void ThenIShouldSeeAllUsersThatContainThis(string phrase)
        {
            var users = _scenarioContext.Get<IEnumerable<UserEntity>>("usersContainPhrase");

            foreach (var user in users)
            {
                Assert.That(user.Email.Contains(phrase), $"{phrase} is not contained in that record. User email is {user.Email}");
            }
        }
    }
}
