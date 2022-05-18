using DBTesting.DataContext;
using DBTesting.DBContext;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DBTesting.StepDefinitions
{
    [Binding]
    public class UpdateUserStepDefinitions
    {

        private FeatureContext _featureContext;
        private ScenarioContext _scenarioContext;
        private MainRepository _repo;

        public UpdateUserStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _repo = _featureContext.Get<MainRepository>(DBContext.Labels.MainRepository);
        }

        [Given(@"I have already created user")]
        public void GivenIHaveAlreadyCreatedUser()
        {
            _repo.Repository.Create(TestData.DefaultUser);

            _scenarioContext.Add("lastUserID", TestData.DefaultUser.Id);
        }

        [When(@"I update his first name to ""([^""]*)""")]
        public void WhenIUpdateHisFirstNameTo(string firstName)
        {
            var userFromDBLastID = _scenarioContext.Get<int>("lastUserID");
            var userFromDB = _repo.Repository.Get(userFromDBLastID);

            userFromDB.FirstName = firstName;
            _scenarioContext.Add("changedFirstName", firstName);

            _repo.Repository.Update(userFromDB);
        }

        [Then(@"I should see his first name changed")]
        public void ThenIShouldSeeHisFirstNameChangedTo()
        {
            var userFromDBLastID = _scenarioContext.Get<int>("lastUserID");
            var changedFirstName = _scenarioContext.Get<string>("changedFirstName");

            _repo.Repository.Reload(TestData.DefaultUser);
            var userFromDB = _repo.Repository.Get(userFromDBLastID);


            Assert.That(userFromDB.FirstName, Is.EqualTo(changedFirstName), "First name does not match with the changed one");
        }
    }
}
