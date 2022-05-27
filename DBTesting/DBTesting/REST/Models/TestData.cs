using DBTesting.Helpers;

namespace DBTesting.REST.Models
{
    internal class TestData
    {
        public static User GetNewUser() => new User
        {
            Title = "Mr.",
            FirstName = "Test",
            SirName = "Test",
            City = "Test",
            Country = "Test",
            Email = Helper.GetRandomEmail(),
            Password = "pass123",
            IsAdmin = 0
        };
    }
}
