using System;
using System.IO;
using System.Net;
using TelegramBot.API_Classes;

namespace TelegramBot
{
    class SimpleBot
    {
        const string TOKEN = @"375416144:AAHDLsJ_0MOow-u_LbwdWqRvfB4uyRByryQ";
        const string URI = @"https://api.telegram.org/bot";
        const string GETUPDATES = @"/getUpdates";

        private int _updateId = 0;

        public void StartBot()
        {
            while (true)
            {
                GetUpdates();
                System.Threading.Thread.Sleep(1000);
            }
        }

        void GetUpdates()
        {
            Console.WriteLine($"Обновление: {_updateId}");
            var req = (HttpWebRequest)WebRequest.Create($"{URI}{TOKEN}{GETUPDATES}?offset={(_updateId + 1)}");
            var resp = (HttpWebResponse)req.GetResponse();

            using (var sReader = new StreamReader(resp.GetResponseStream()))
            {
                string responsedJson = sReader.ReadToEnd();

                try
                {
                    var currentUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responsedJson);
                    string messageText = null;
                    foreach (var current in currentUpdate.Updates)
                    {
                        _updateId = current.UpdateId;
                        messageText = current.Message.Text;
                        updateMessage(messageText); // Our sexy delegate
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Fail||{e.Message}");
                }
            }
        }

        public event ControlMessages updateMessage;
    }
    internal delegate void ControlMessages(string message );
}