using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTesting.Helping
{
    internal class Helper
    {        internal static string GetRandomEmail()
        {
            Random random = new Random();

            string email = string.Format("qa{0:00000000}@test.com", random.Next(10000000));

            return email;
        }

        internal static int GetRandomIntFrom1To10()
        {
            Random random = new Random();
            int number = random.Next(1, 10);

            return number;
        }
    }
}
