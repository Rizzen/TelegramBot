using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace TelegramBot.NyaBot
{
    internal class BotApiClient
    {
        const string BASE_API_ADDRESS = @"https://api.telegram.org/bot";

        private string token;

        public BotApiClient(string token)
        {
            this.token = token;
        }

        public void SendRequest(string methodName, object o)
        {
            HttpWebResponse response = null;
            StreamWriter streamWriter = null;

            try
            {
                var jsonText = JsonConvert.SerializeObject(o, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                var webRequest = (HttpWebRequest)WebRequest.Create($"{BASE_API_ADDRESS}{token}/{methodName}");
                webRequest.ContentType = "application/json";
                webRequest.Method = "POST";

                using (streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonText);
                }

                response = (HttpWebResponse)webRequest.GetResponse();
                // добавить сюда получение ответа, если он нужен
                response?.Close();
            }
            catch (Exception e)
            {
                streamWriter?.Dispose();
                response?.Dispose();
                Console.WriteLine(e);
            }
        }

        public string DownloadString(string method)
        {
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            string result = String.Empty;

            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create($"{BASE_API_ADDRESS}{token}/{method}");
                response = (HttpWebResponse)webRequest.GetResponse();

                using (streamReader = new StreamReader(response.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            response?.Dispose();
            streamReader?.Dispose();

            return result;
        }
    }
}
