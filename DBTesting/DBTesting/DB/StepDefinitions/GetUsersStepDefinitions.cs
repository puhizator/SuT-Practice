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

        [When(@"I Get user by email ""([^""]*)""")]
        public void WhenGetUserByEmail(string email)
        {
            var users = _repo.Repository.Get(e => e.Email == email);

            var returnedUser = users.First();

            _scenarioContext.Add("returnedUserEmail", returnedUser.Email);
            _scenarioContext.Add("inputEmail", email);
        }

        [When(@"Get users by email containing ""([^""]*)""")]
        public void WhenGetUsersByEmailContaining(string phrase)
        {
            var usersIEnum = _repo.Repository.Get(entity => entity.Email.Contains(phrase));
            var users = new List<UserEntity>();

            foreach (var u in usersIEnum)
            {
                users.Add(u);
            }

            _scenarioContext.Add("usersContainPhrase", users);
        }

        [Then(@"I should be able to see list of all users")]
        public void ThenIShouldBeAbleToSeeListOfAllUsers()
        {
            Assert.That(_scenarioContext.Get<int>("collectionCount") > 0);
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

            Assert.That(returnedFirstUserID, Is.EqualTo(firstUser.Id));
        }

        [Then(@"I should see user with the same email")]
        public void ThenIShouldSeeUserWithTheSameEmail()
        {
            var returnedUserEmail = _scenarioContext.Get<string>("returnedUserEmail");
            var inputEmail = _scenarioContext.Get<string>("inputEmail");

            Assert.AreEqual(returnedUserEmail, inputEmail);
        }

        [Then(@"I should see all users that contain this ""([^""]*)"" in their emails")]
        public void ThenIShouldSeeAllUsersThatContainThis(string phrase)
        {
            var users = _scenarioContext.Get<List<UserEntity>>("usersContainPhrase");

            foreach (var user in users)
            {
                Assert.That(user.Email.Contains(phrase), $"{phrase} is not contained in that record. User email is {user.Email}");
            }
        }
    }
}
