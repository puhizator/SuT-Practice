using DBTesting.Configurations;
using DBTesting.REST.Models;
using RestSharp;
using System.Collections.Generic;

namespace DBTesting.REST.Utils
{
    internal class BaseRestClient
    {
        RestClient _restClient;
        RestRequest _request;

        public BaseRestClient()
        {
            _restClient = new RestClient(ConfigurationProvider.GetValue[ConfigurationLabels.RestBaseUrl]);
        }
        public RestResponse<List<User>> GetAllUsers()
        {
            _request = new RestRequest(ConfigurationProvider.GetValue[ConfigurationLabels.UsersEndPoint], Method.Get);

            return _restClient.ExecuteAsync<List<User>>(_request).Result;
        }
        public RestResponse<User> GetSingleUser(int id)
        {
            _request = new RestRequest($"{ConfigurationProvider.GetValue[ConfigurationLabels.UsersEndPoint]}/{id}", Method.Get);

            return _restClient.ExecuteAsync<User>(_request).Result;
        }

        public RestResponse<User> PostSingleUser(User user)
        {
            _request = new RestRequest(ConfigurationProvider.GetValue[ConfigurationLabels.UsersEndPoint], Method.Post)
                .AddJsonBody(user);

            return _restClient.ExecuteAsync<User>(_request).Result;
        }
    }
}
