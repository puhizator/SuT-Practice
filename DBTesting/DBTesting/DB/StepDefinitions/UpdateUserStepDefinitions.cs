using DBTesting.DB.DataContext;
using DBTesting.DB.DBContext;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DBTesting.DB.StepDefinitions
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
            _repo = _featureContext.Get<MainRepository>(Labels.MainRepository);
        }

        [Given(@"I have already created user")]
        public void GivenIHaveAlreadyCreatedUser()
        {
            var userToBeAdded = TestData.GetNewUser();

            _repo.Repository.Create(userToBeAdded);

            _scenarioContext.Add("lastUserID", userToBeAdded.Id);
        }


        [When(@"I update his first name to '(.*)'")]
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
            var userForReload = _repo.Repository.Get(userFromDBLastID);
            var changedFirstName = _scenarioContext.Get<string>("changedFirstName");

            _repo.Repository.Reload(userForReload);
            var userFromDB = _repo.Repository.Get(userFromDBLastID);


            Assert.That(userFromDB.FirstName, Is.EqualTo(changedFirstName), "First name does not match with the changed one");
        }
    }
}
