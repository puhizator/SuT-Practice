using DBTesting.DataContext;
using DBTesting.Models;
using NUnit.Framework;
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

            var first = _repo.Repository.GetFirst();

            var get = _repo.Repository.Get(entity => entity.FirstName.Contains("an"));

            foreach (var user in get)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(user.FirstName.Contains("an"), "an not found");
                    Assert.That(user.FirstName.Contains("a"), "a not found");
                }
                );
            }

            Console.WriteLine("x");
        }
    }
}
