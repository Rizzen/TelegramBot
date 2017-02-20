using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    public class AsyncBot
    {
        const string URI = @"https://api.telegram.org/bot";
        const string TOKEN = @"338653456:AAG1qOkwffo7YGkYdNNlF5d2MH-U09Wqoro";
        const string GET_UPDATES = @"/getUpdates";
        const string SEND_MESSAGE = @"/sendMessage";

        private int _offset;

        public AsyncBot()
        {
            GetUpdates();
            Console.Read();
        }

        private async void GetUpdates()
        {
            var webReq = WebRequest.Create(URI + TOKEN + GET_UPDATES);
            var webResp = await webReq.GetResponseAsync();
            await ParseRequest(webResp);
            SendMessage("309426750", "mur-mur-mur-mur");
        }

        private async Task<string> ParseRequest(WebResponse webResp)
        {
            using (var stream = webResp.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        private void SendMessage(string chat, string text)
        {
            var webReq = WebRequest.Create($"{URI}{TOKEN}{SEND_MESSAGE}?chat_id={chat}&text={text}");
            webReq.Method = "POST";
            var webResp = webReq.GetResponse();
            ;
        }
    }
}
