using DBTesting.DataContext;
using DBTesting.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace DBTesting.StepDefinitions
{
    [Binding]
    public class GetAllUsersStepDefinitions
    {
        private FeatureContext _featureContext;
        private MainRepository _repo;

        public GetAllUsersStepDefinitions(FeatureContext featureContext)
        {
            _featureContext = featureContext;
            _repo = _featureContext.Get<MainRepository>(DBContext.Labels.MainRepository);
        }

        [Given(@"Get all users")]
        public void GivenGetAllUsers()
        {
            var dbSet = _repo.Repository.GetAll();

            Console.WriteLine("x");
        }
    }
}
