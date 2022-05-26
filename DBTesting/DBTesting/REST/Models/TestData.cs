using DBTesting.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTesting.REST.Models
{
    internal class TestData
    {
        public static User DefaultUser() => new User
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
