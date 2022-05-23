using DBTesting.DataContext;
using DBTesting.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace DBTesting.StepDefinitions
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
            _repo = _featureContext.Get<MainRepository>(DBContext.Labels.MainRepository);
            _scenarioContext = scenarioContext;
        }

        [When(@"Get all users")]
        public void GivenGetAllUsers()
        {
            var dbSet = _repo.Repository.GetAll();
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
            var first = _repo.Repository.GetFirst();
        }

        [When(@"Get user by email ""([^""]*)""")]
        public void WhenGetUserByEmail(string email)
        {
            _repo.Repository.Get(e => e.Email == email);
        }

        [When(@"Get users by email containing ""([^""]*)""")]
        public void WhenGetUsersByEmailContaining(string phrase)
        {
            var users = _repo.Repository.Get(entity => entity.Email.Contains(phrase));

            _scenarioContext.Add("usersContainPhrase", users);
        }

        [Then(@"I should be able to see list of all users")]
        public void ThenIShouldBeAbleToSeeListOfAllUsers()
        {
            throw new PendingStepException();
        }

        [Then(@"I should see user with ID (.*)")]
        public void ThenIShouldSeeUserWithID(int id)
        {
            var givenUser = _scenarioContext.Get<UserEntity>("userByID");

            var dbUser = _repo.Repository.Get(id);

            Assert.That(givenUser, Is.EqualTo(dbUser));
        }

        [Then(@"I should see first user")]
        public void ThenIShouldSeeFirstUser()
        {
            throw new PendingStepException();
        }

        [Then(@"I should see user with the same email")]
        public void ThenIShouldSeeUserWithTheSameEmail()
        {
            throw new PendingStepException();
        }

        [Then(@"I should see all users that contain this ""([^""]*)""")]
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
