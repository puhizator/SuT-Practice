using DBTesting.DataContext;
using TechTalk.SpecFlow;

namespace DBTesting.Hooks
{
    [Binding]
    [Scope(Feature = "GetAllUsers")]
    public sealed class Hooks
    {
        [BeforeFeature]

        public static void FeatureSetUp(FeatureContext featureContext)
        {
            featureContext.Add(DBContext.Labels.MainRepository, new MainRepository());
        }
    }
}
