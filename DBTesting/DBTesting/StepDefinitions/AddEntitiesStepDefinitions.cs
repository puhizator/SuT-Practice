using DBTesting.DataContext;
using DBTesting.DBContext;
using DBTesting.Models;
using DBTesting.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TechTalk.SpecFlow;

namespace DBTesting.StepDefinitions
{
    [Binding]
    public class AddEntitiesStepDefinitions
    {

        private FeatureContext _featureContext;
        private ScenarioContext _scenarioContext;
        private MainRepository _repo;

        public AddEntitiesStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _repo = _featureContext.Get<MainRepository>(DBContext.Labels.MainRepository);
        }

        [When(@"I add single Entity")]
        public void WhenIAddSingleEntity()
        {
            var userToAdd = TestData.GenerateNewUser();
            _repo.Repository.Create(userToAdd);

            _scenarioContext.Add("lastUserID", userToAdd.Id);
            _scenarioContext.Add("lastUser", userToAdd);
        }

        [When(@"I add multiple entities")]
        public void WhenIAddMultipleEntities()
        {
            var entitiesToBeAdded = new List<UserEntity>();

            int randomNumberTo10 = Helper.GetRandomIntFrom1To10();

            for (int i = 0; i < randomNumberTo10; i++)
            {
                var user = TestData.GenerateNewUser();
                entitiesToBeAdded.Add(user);
            }

            IReadOnlyCollection<UserEntity> readOnlyEntitiesToBeAdded = entitiesToBeAdded;

            _repo.Repository.AddRangeReadOnly(readOnlyEntitiesToBeAdded);

            _scenarioContext.Add("usersToBeDeleted", readOnlyEntitiesToBeAdded);
        }

        [Then(@"I should be able to see that user in DB")]
        public void ThenIShouldBeAbleToSeeThatUserInDB()
        {
            var userFromDBLastID = _scenarioContext.Get<int>("lastUserID");
            var userSavedInScenario = _scenarioContext.Get<UserEntity>("lastUser");
            var userFromDB = _repo.Repository.Get(userFromDBLastID);

            var initialUser = JsonConvert.DeserializeObject<UserEntity>(JsonConvert.SerializeObject(userSavedInScenario));

            _repo.Repository.Reload(userFromDB);

            Assert.Multiple(() =>
            {
                Assert.That(userFromDB.Title, Is.EqualTo(initialUser.Title), "Title does not match");
                Assert.That(userFromDB.FirstName, Is.EqualTo(initialUser.FirstName), "FirstName does not match");
                Assert.That(userFromDB.SirName, Is.EqualTo(initialUser.SirName), "SirName does not match");
                Assert.That(userFromDB.Country, Is.EqualTo(initialUser.Country), "Country does not match");
                Assert.That(userFromDB.City, Is.EqualTo(initialUser.City), "City does not match");
                Assert.That(userFromDB.Email, Is.EqualTo(initialUser.Email), "Email does not match");
                Assert.That(userFromDB.Password, Is.EqualTo(initialUser.Password), "Password does not match");
                Assert.That(userFromDB.IsAdmin, Is.EqualTo(initialUser.IsAdmin), "User admin rights are not correct");
            });
        }

        [Then(@"I should be able to see all of the users in DB")]
        public void ThenIShouldBeAbleToSeeAllOfTheUsersInDB()
        {
            var users = _scenarioContext.Get<List<UserEntity>>("usersToBeDeleted");

            _repo.Repository.Reload(users.FirstOrDefault());

            for (int i = 0; i < users.Count; i++)
            {
                Assert.That(_repo.Repository.Contains(u => u.Email == users[i].Email), $"{users[i].Email} does not exist");
            }
        }

    }
}
