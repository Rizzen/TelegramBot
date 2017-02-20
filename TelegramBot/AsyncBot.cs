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
        const string TOKEN = @"375416144:AAHDLsJ_0MOow-u_LbwdWqRvfB4uyRByryQ";

        private int _offset;

        public AsyncBot()
        {
            GetUpdates();
            Console.Read();
        }

        private async void GetUpdates()
        {
            var webReq = WebRequest.Create("https://api.telegram.org/bot" + TOKEN + "/getUpdates");
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
            ;
        }
    }
}
