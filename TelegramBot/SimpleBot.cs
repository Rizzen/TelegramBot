using System;
using System.IO;
using System.Net;
using TelegramBot.API_Classes;
using System.Threading;

namespace TelegramBot
{
    class SimpleBot
    {
        const string TOKEN = @"375416144:AAHDLsJ_0MOow-u_LbwdWqRvfB4uyRByryQ";
        const string URI = @"https://api.telegram.org/bot";
        //static int UpdateID = 0; 

        public SimpleBot()
        {
            while (true)
            {
                GetUpdates();
                Thread.Sleep(1000);
            }
        }

        void GetUpdates()
        {
            var req = (HttpWebRequest)WebRequest.Create(URI + TOKEN + "/getUpdates");
            //Console.WriteLine("{0}", UpdateID + 1);
            var resp = (HttpWebResponse)req.GetResponse();


            using (var sReader = new StreamReader(resp.GetResponseStream()))
            {
                string responsedJson = sReader.ReadToEnd();
                var currentUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<Update>(responsedJson);
                //Console.Write(currentUpdate.Message);
                sReader.Close();
            }

            //Console.ReadLine();
        }

        //void MakeRequest(string method)
        //{
        //    var req = (HttpWebRequest)WebRequest.Create(URI + TOKEN + method);
        //    var resp = (HttpWebResponse)req.GetResponse();


        //}
    }
}
