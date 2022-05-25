using DBTesting.Configurations;
using DBTesting.DBContext;
using DBTesting.Models;
using DBTesting.Utils;

namespace DBTesting.DataContext
{
    public class MainRepository
    {
        public BaseClient<SuTContext, UserEntity> Repository { get; }

        public MainRepository()
        {
            var connection = ConfigurationProvider.GetValue[Labels.DBConnectionString];
            Repository = new BaseClient<SuTContext, UserEntity>(connection);
        }
    }
}
