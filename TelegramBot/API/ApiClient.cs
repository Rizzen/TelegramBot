using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TelegramBot.Utils;

namespace TelegramBot.API
{
    /// <summary>Providing API requests</summary>
    public class ApiClient
    {
        private readonly string baseApiAdress = "https://api.telegram.org/bot";

        private readonly IRestClient _client;

        public ApiClient(string token)
        {
            _client = new RestClient($"{baseApiAdress}{token}");
        }

        /// <summary> Calling specified method</summary>
        public Task<TResult> SendRequestAsync<TResult>(string method, object obj = null)
        {
            var request = new RestRequest(method, Method.POST) {RequestFormat = DataFormat.Json};
            if (obj != null)
            {
                request.AddHeader("Content-type", "application/json");
                request.JsonSerializer = NewtonsoftJsonSerializer.Default;
                request.AddBody(obj);
            }
            
            return Post<TResult>(request);
        }

       /// <summary> Providing POST request throw RESTSharp </summary>
        private async Task<TResult> Post<TResult>(IRestRequest request)
        {
            var responce = await _client.ExecutePostTaskAsync(request);

            var result = JsonConvert.DeserializeObject<TResult>(responce.Content);
            return result;
        }
    }
}
