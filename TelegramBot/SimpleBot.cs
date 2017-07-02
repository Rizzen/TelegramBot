using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TelegramBot.API;
using Newtonsoft.Json;

namespace TelegramBot
{
    class SimpleBot
    {
        const string TOKEN = @"437367398:AAEE6VZNK7LOEBcyJiKpR2_o6LMGGUSTyV8";
        const string URI = @"https://api.telegram.org/bot";
        const string GETUPDATES = @"/getUpdates";

        private int _updateId = 0;

        public void StartBot()
        {
            while (true)
            {
                GetUpdates();
                Thread.Sleep(1000);
            }
        }


        public void GetUpdates ()
        {
            Console.WriteLine($"Update #{_updateId}");
            var request = (HttpWebRequest)WebRequest.Create($"{URI}{TOKEN}{GETUPDATES}?offset={_updateId + 1}");
            var resp = (HttpWebResponse)request.GetResponse();

            var sReader = new StreamReader(resp.GetResponseStream());

            string responsedJson = sReader.ReadToEnd();
            
            try
            {
                var currentUpdate = JsonConvert.DeserializeObject<Responce>(responsedJson);
                string messageText = null;
                foreach (var current in currentUpdate.Updates)
                {
                    _updateId = current.UpdateId;
                    messageText = current.Message.Text;
                    Console.WriteLine(messageText);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Update Failed {e.Message}");
            }
        }
    }
}
