using DBTesting.Configurations;
using DBTesting.DB.DBContext;
using DBTesting.DB.Models;
using DBTesting.DB.Utils;

namespace DBTesting.DB.DataContext
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
