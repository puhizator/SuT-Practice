using DBTesting.Configurations;
using DBTesting.DB.DBContext;
using DBTesting.DB.Models;
using DBTesting.DB.Utils;

namespace DBTesting.DB.DataContext
{
    public class MainRepository
    {
        public BaseDBClient<SuTContext, UserEntity> Repository { get; }

        public MainRepository()
        {
            var connection = ConfigurationProvider.GetValue[DBLabels.DBConnectionString];
            Repository = new BaseDBClient<SuTContext, UserEntity>(connection);
        }
    }
}
