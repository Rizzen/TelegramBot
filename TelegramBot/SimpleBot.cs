using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace TelegramBot
{
    class SimpleBot
    {
        const string TOKEN = @"375416144:AAHDLsJ_0MOow-u_LbwdWqRvfB4uyRByryQ";
        string responsedJson = "";
        public SimpleBot()
        {
            GetUpdates();
            var currentUpdate = JsonConvert.DeserializeObject<Update>(responsedJson);

        }

        void GetUpdates()
        {
            var req = (HttpWebRequest)WebRequest.Create("https://api.telegram.org/bot" + TOKEN + "/getUpdates");
            var resp = (HttpWebResponse)req.GetResponse();


            using (var sReader = new StreamReader(resp.GetResponseStream()))
            {
                string responsedJson = sReader.ReadToEnd();
                //Console.WriteLine(readed);
                sReader.Close();
            }

            Console.ReadLine();
        }
    }
}
