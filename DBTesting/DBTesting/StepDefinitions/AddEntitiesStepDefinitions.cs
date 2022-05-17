using DBTesting.DataContext;
using DBTesting.DBContext;
using DBTesting.Models;
using Newtonsoft.Json;
using NUnit.Framework;
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
    }
}
