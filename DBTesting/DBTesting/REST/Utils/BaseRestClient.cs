using DBTesting.Configurations;
using DBTesting.REST.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTesting.REST.Utils
{
    internal class BaseRestClient
    {
        RestClient _restClient;
        RestRequest _request;
        RestResponse _response;

        public BaseRestClient()
        {
            _restClient = new RestClient(ConfigurationProvider.GetValue[ConfigurationLabels.RestBaseUrl]);
        }

        public int ResponseCode { get => ((int)_response.StatusCode); }
        public string ResponseMessage { get => (_response.StatusDescription); }
        public string ResponseContent { get => (_response.Content); }

        public void GetAllUsers()
        {
            _request = new RestRequest(ConfigurationProvider.GetValue[ConfigurationLabels.UsersEndPoint], Method.Get);

            _response = _restClient.ExecuteAsync(_request).Result;
        }
        public void GetSingleUser(int id)
        {
            _request = new RestRequest($"{ConfigurationProvider.GetValue[ConfigurationLabels.UsersEndPoint]}/{id}", Method.Get);

            _response = _restClient.ExecuteAsync(_request).Result;
        }

        public void PostSingleUser(User user)
        {
            _request = new RestRequest(ConfigurationProvider.GetValue[ConfigurationLabels.UsersEndPoint], Method.Post)
                .AddJsonBody(user);

            _response = _restClient.ExecuteAsync(_request).Result;
        }


    }
}
