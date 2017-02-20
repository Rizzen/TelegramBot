using System;
using System.Collections.Generic;
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
            var webReq = (HttpWebRequest)WebRequest.Create("https://api.telegram.org/bot" + TOKEN + "/getUpdates");
            var webResp = await webReq.GetResponseAsync();
            ParseRequest(webResp);
        }

        private void ParseRequest(WebResponse webResp)
        {
            ;
        }

        private void SendResponse(string request)
        {

        }
    }
}
