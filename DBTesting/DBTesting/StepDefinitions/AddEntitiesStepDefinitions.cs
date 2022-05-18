using DBTesting.DataContext;
using DBTesting.DBContext;
using DBTesting.Models;
using DBTesting.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
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
            _repo.Repository.Create(TestData.DefaultUser);

            _scenarioContext.Add("lastUserID", TestData.DefaultUser.Id);
        }

        [When(@"I add multiple entities")]
        public void WhenIAddMultipleEntities()
        {
            var entitiesToBeAdded = new List<UserEntity>();
            var idsToBeDeleted = new List<int>();

            int randomNumberTo10 = Helper.GetRandomIntFrom1To10();

            for (int i = 0; i < randomNumberTo10; i++)
            {
                var user = TestData.GenerateNewUser();
                entitiesToBeAdded.Add(user);
            }

            _repo.Repository.AddRange(entitiesToBeAdded);

            foreach (var e in entitiesToBeAdded)
            {
                idsToBeDeleted.Add(e.Id);
            }

            _scenarioContext.Add("idsToBeDeleted", idsToBeDeleted);
        }

        [Then(@"I should be able to see that user in DB")]
        public void ThenIShouldBeAbleToSeeThatUserInDB()
        {
            var userFromDBLastID = _scenarioContext.Get<int>("lastUserID");
            var userFromDB = _repo.Repository.Get(userFromDBLastID);

            var defaultUserData = JsonConvert.DeserializeObject<UserEntity>(JsonConvert.SerializeObject(TestData.DefaultUser));

            _repo.Repository.Reload(userFromDB);

            Assert.Multiple(() =>
            {
                Assert.That(userFromDB.Title, Is.EqualTo(defaultUserData.Title), "Title does not match");
                Assert.That(userFromDB.FirstName, Is.EqualTo(defaultUserData.FirstName), "FirstName does not match");
                Assert.That(userFromDB.SirName, Is.EqualTo(defaultUserData.SirName), "SirName does not match");
                Assert.That(userFromDB.Country, Is.EqualTo(defaultUserData.Country), "Country does not match");
                Assert.That(userFromDB.City, Is.EqualTo(defaultUserData.City), "City does not match");
                Assert.That(userFromDB.Email, Is.EqualTo(defaultUserData.Email), "Email does not match");
                Assert.That(userFromDB.Password, Is.EqualTo(defaultUserData.Password), "Password does not match");
                Assert.That(userFromDB.IsAdmin, Is.EqualTo(defaultUserData.IsAdmin), "User admin rights are not correct");
            });
        }

        [Then(@"I should be able to see all of the users in DB")]
        public void ThenIShouldBeAbleToSeeAllOfTheUsersInDB()
        {
            var idsLastCreatedUsers = _scenarioContext.Get<List<int>>("idsToBeDeleted");

            foreach (var id in idsLastCreatedUsers)
            {
                var userFromDB = _repo.Repository.Get(id);

                Assert.That(userFromDB, Is.Not.Null);
            }
        }

    }
}
