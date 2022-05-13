using DBTesting.DataContext;
using DBTesting.DBContext;
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
            Assert.That(_repo.Repository.Contains(p => p.Email == TestData.DefaultUser.Email));
        }
    }
}
