using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TelegramBot.NyaBot
{
    internal class BotApiClient
    {
        const string baseApiAddress = @"https://api.telegram.org/bot";

        private readonly string token;

        public BotApiClient(string token)
        {
            this.token = token;
        }

        public string SendRequest(string methodName, object o)
        {
            StreamWriter streamWriter = null;
            StreamReader streamReader = null;
            var result = String.Empty;

            try
            {
                var jsonText = JsonConvert.SerializeObject(o, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                var webRequest = (HttpWebRequest)WebRequest.Create($"{baseApiAddress}{token}/{methodName}");
                webRequest.ContentType = "application/json";
                webRequest.Method = "POST";

                using (streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonText);
                }

                var response = (HttpWebResponse)webRequest.GetResponse();
                using (streamReader = new StreamReader(response.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }
            streamWriter?.Close();
            streamReader?.Close();

            return result;
        }

        public async Task<string> SendRequestAsync(string methodName, object o)
        {
            StreamWriter streamWriter = null;
            StreamReader streamReader = null;
            var result = String.Empty;

            try
            {
                var jsonText = JsonConvert.SerializeObject(o, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                var request = (HttpWebRequest)WebRequest.Create($"{baseApiAddress}{token}/{methodName}");
                request.ContentType = "application/json";
                request.Method = "POST";

                var requestStream = await request.GetRequestStreamAsync();
                using (streamWriter = new StreamWriter(requestStream))
                {
                    await streamWriter.WriteAsync(jsonText);
                }

                var response = await request.GetResponseAsync() as HttpWebResponse;
                using (streamReader = new StreamReader(response.GetResponseStream()))
                {
                    result = await streamReader.ReadToEndAsync();
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }
            streamWriter?.Close();
            streamWriter?.Close();

            return result;
        }
    }
}
