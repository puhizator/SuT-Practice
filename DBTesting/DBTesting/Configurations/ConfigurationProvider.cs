using System.IO;
using Microsoft.Extensions.Configuration;

namespace DBTesting.Configurations
{
    static class ConfigurationProvider
    {
        public static IConfiguration GetValue { get; }

        static ConfigurationProvider()
        {
            GetValue = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
