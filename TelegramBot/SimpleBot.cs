using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TelegramBot.API_Classes;

namespace TelegramBot
{
    class SimpleBot
    {
        const string TOKEN = @"375416144:AAHDLsJ_0MOow-u_LbwdWqRvfB4uyRByryQ";
        const string URI = @"https://api.telegram.org/bot";

        private int _updateID = 0;

        public SimpleBot()
        {
            GetUpdates();
        }

        void GetUpdates()
        {
            var req = (HttpWebRequest)WebRequest.Create(URI + TOKEN + "/getUpdates");
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
                        foreach (var update in currentUpdate.Updates)
                        {
                            Console.WriteLine(update.Message.Text);
                            // _updateID = update.UpdateId + 1; — пока пусть будет закоменчено, чтобы не очищать эвенты
                            // здесь будем обрабатывать или класть в очередь
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Fail");
                    }

                }
            }
            Console.ReadLine();
        }
    }
}