using System;
using System.IO;
using System.Net;
using TelegramBot.API_Classes;

namespace TelegramBot
{
    class SimpleBot
    {
        const string TOKEN = @"375416144:AAHDLsJ_0MOow-u_LbwdWqRvfB4uyRByryQ";
        public SimpleBot()
        {
            GetUpdates();
        }

        void GetUpdates()
        {
            var req = (HttpWebRequest)WebRequest.Create("https://api.telegram.org/bot" + TOKEN + "/getUpdates");
            var resp = (HttpWebResponse)req.GetResponse();


            using (var sReader = new StreamReader(resp.GetResponseStream()))
            {
                string responsedJson = sReader.ReadToEnd();
                //var currentUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<Update>(responsedJson); сделайте что-нибудь с этой хуйней, я туплю уже
                Console.WriteLine(responsedJson);
                sReader.Close();
            }

            Console.ReadLine();
        }
    }
}
