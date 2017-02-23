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
            Console.WriteLine("Обновление: {0}", _updateId);
            var req = (HttpWebRequest)WebRequest.Create(URI + TOKEN + "/getUpdates" + "?offset=" + (_updateId + 1));
            var resp = (HttpWebResponse)req.GetResponse();

            using (var stream = resp.GetResponseStream())
            {
                using (var sReader = new StreamReader(stream))
                {
                    string responsedJson = sReader.ReadToEnd();
                    sReader.Close();

                    try
                    {
                        var currentUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responsedJson);
                        string messageText = "hail";
                        foreach (var current in currentUpdate.Updates)
                        {
                            _updateId = current.UpdateId;
                            messageText = current.Message.Text;
                            updateMessage(messageText); // Our sexy delegate
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Fail||{e}");
                    }

                }
            }

            //Console.ReadLine();
        }

        public event ControlMessages updateMessage;
    }
    internal delegate void ControlMessages(string message );
}