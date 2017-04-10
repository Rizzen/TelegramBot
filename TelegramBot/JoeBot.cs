using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading;
using TelegramBot.API.Models;

namespace TelegramBot
{
    public class JoeBot
    {
        const string Uri = @"https://api.telegram.org/bot";
        const string Token = @"338653456:AAG1qOkwffo7YGkYdNNlF5d2MH-U09Wqoro";
        const string GET_UPDATES = @"/getUpdates";
        const string SEND_MESSAGE = @"/sendMessage";

        private bool _started;
        private int _offset;

        public JoeBot()
        {
            _started = true;
            Console.WriteLine("Bot started");

            while (_started)
            {
                try
                {
                    GetUpdates();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error when getting updates: {ex.Message}");
                }

                Thread.Sleep(1000);
            }

            ClearLastUpdate();
            Console.WriteLine("Bot stopped");
            Console.Read();
        }

        private void GetUpdates()
        {
            var reqParams = _offset > 0 ? $"?timeout=1&offset={_offset}" : "?timeout=1";
            var webReq = WebRequest.Create($"{Uri}{Token}{GET_UPDATES}{reqParams}");
            webReq.Timeout = 3000;
            Console.WriteLine($"Request {webReq.RequestUri.ToString()} sent");
            var webResp = webReq.GetResponse();
            var response = ParseRequest(webResp);

            if (response.Success && response.Updates.Length > 0)
            {
                Console.WriteLine($"{response.Updates.Length} updates found");

                foreach (var update in response.Updates)
                {
                    _offset = update.UpdateId + 1;
                    var chat = update.Message?.Chat;

                    if (chat != null && chat.Id != 0 && update.Message.Text != null)
                    {
                        var text = update.Message.Text;

                        if (text.ToLowerInvariant() == "stop")
                        {
                            SendMessage(chat.Id, "Hammertime!");
                            _started = false;
                        }
                        else if (text.ToLowerInvariant().Contains("sup bot"))
                        {
                            SendMessage(chat.Id, "mur-mur-mur-mur");
                        }
                    }
                }
            }
            else
            {
                if (!response.Success)
                {
                    Console.WriteLine("Getting updates failed");
                }
                else if (response.Updates.Length == 0)
                {
                    Console.WriteLine("No updates");
                }
            }
        }

        private void ClearLastUpdate()
        {
            if (_offset > 0)
            {
                var reqParams = _offset > 0 ? $"?timeout=1&offset={_offset}" : "?timeout=1";
                var webReq = WebRequest.Create($"{Uri}{Token}{GET_UPDATES}{reqParams}");
                Console.WriteLine($"Request {webReq.RequestUri.ToString()} sent");
                var webResp = webReq.GetResponse();
                var response = ParseRequest(webResp);

                if (!response.Success)
                {
                    ClearLastUpdate();
                }
            }
        }

        private Response ParseRequest(WebResponse webResp)
        {
            var stream = webResp.GetResponseStream();

            try
            {
                var reader = new StreamReader(stream);

                try
                {
                    return JsonConvert.DeserializeObject<Response>(reader.ReadToEnd());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error when parsing response: {ex.Message}");
                    return new Response();
                }
                finally
                {
                    reader?.Close();
                    reader.Dispose();
                }
            }
            finally
            {
                stream?.Close();
                stream?.Dispose();
            }
        }

        private void SendMessage(long chat, string text)
        {
            SendMessage(chat.ToString(), text);
        }

        private void SendMessage(string chat, string text)
        {
            try
            {
                var webReq = WebRequest.Create($"{Uri}{Token}{SEND_MESSAGE}?chat_id={chat}&text={text}");
                webReq.Timeout = 3000;
                webReq.Method = "POST";
                Console.WriteLine($"Request {webReq.RequestUri.ToString()} sent");
                var webResp = webReq.GetResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when sending request: {ex.Message}");
            }
        }
    }
}
