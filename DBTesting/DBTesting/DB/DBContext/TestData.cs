using DBTesting.DB.Models;
using DBTesting.Helping;

namespace DBTesting.DB.DBContext
{
    public static class TestData
    {
        public static UserEntity GenerateNewUser()
        {
            var user = new UserEntity()
            {
                Title = "Mr.",
                FirstName = "Test",
                SirName = "Test",
                City = "Test",
                Country = "Test",
                Email = Helper.GetRandomEmail(),
                Password = "pass123",
                IsAdmin = false
            };
            return user;
        }
    }
}
