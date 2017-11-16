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
using TelegramBot.API.Types;
using TelegramBot.Utils;
using MessageToSend = TelegramBot.Bot.Types.MessageToSend;

namespace TelegramBot.API
{
    /// <summary>Provides requests through API</summary>
    public class ApiClient
    {
        private const string BaseApiAdress = "https://api.telegram.org/bot";

        private readonly IRestClient _client;

        public ApiClient(string token)
        {
            _client = new RestClient($"{BaseApiAdress}{token}");
        }


        public Task<TResult> SendMessageAsync<TResult>(string message, long chatId)
        {
            var messageToSend = new MessageToSend
            {
                ChatId = chatId,
                Text = message
            };
            return SendRequestAsync<TResult>("sendMessage", messageToSend);
        }

        /// <summary>Calls specified method</summary>
        public Task<TResult> SendRequestAsync<TResult>(string method, object obj = null)
        {
            var request = new RestRequest(method, Method.POST) {RequestFormat = DataFormat.Json};

            if (obj != null)
            {
                request.JsonSerializer = NewtonsoftJsonSerializer.Default;
                request.AddHeader("Content-type", "application/json");
                request.AddBody(obj);
            }
            
            return Post<TResult>(request);
        }

        /// <summary>Sends Photo</summary>
        public Task<TResult> SendPhoto<TResult>(long chatId, byte[] imageBytes, string caption = null)
        {
            var request = new RestRequest("sendPhoto")
            {
                RequestFormat = DataFormat.Json,
                Method = Method.POST
            }
            .AddHeader("Content-Type", "multipart/form-data")
            .AddParameter("chat_id", chatId)
            .AddFile("photo", imageBytes, "imageFile");

            if (caption != null)
            {
                request.AddParameter("caption", caption);
            }

            return Post<TResult>(request);
        }

        /// <summary>Sends Video</summary>
        public Task<TResult> SendVideo<TResult>(long chatId, byte[] videoBytes)
        {
            var request = new RestRequest("sendVideo")
            {
                RequestFormat = DataFormat.Json,
                Method = Method.POST
            }
            .AddHeader("Content-Type", "multipart/form-data")
            .AddParameter("chat_id", chatId)
            .AddFile("video", videoBytes, "videoFile");

            return Post<TResult>(request);
        }

        /// <summary>Sends Document</summary>
        public Task<TResult> SendDocument<TResult>(long chatId, byte[] docBytes)
        {
            var request = new RestRequest("sendVideo")
            {
                RequestFormat = DataFormat.Json,
                Method = Method.POST
            }
            .AddHeader("Content-Type", "multipart/form-data")
            .AddParameter("chat_id", chatId)
            .AddFile("document", docBytes, "file");
            //TODO add ext method "AddIfNotNull" and add here other optional params from Document Class

            return Post<TResult>(request);
        }

        public Task<bool> SetWebHook(string uri = "", int maxConnections = 40)
        {
            var parameters = new Dictionary<string, object>
            {
                { "uri", uri},
                { "max_connections", maxConnections}
            };

            return SendRequestAsync<bool>("setWebhook", parameters);
        }

        /// <summary> Providing POST request using RESTSharp </summary>
        private async Task<TResult> Post<TResult>(IRestRequest request)
        {
            var responce = await _client.ExecutePostTaskAsync(request);

            return JsonConvert.DeserializeObject<ApiResponce<TResult>>(responce.Content).ResultObject;
        }
    }
}
