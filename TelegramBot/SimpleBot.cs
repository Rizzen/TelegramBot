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

        private int _updateID = 0;

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
            Console.WriteLine("Обновление: {0}", _updateID);
            var req = (HttpWebRequest)WebRequest.Create(URI + TOKEN + "/getUpdates" + "?offset="+ (_updateID + 1));
            var resp = (HttpWebResponse)req.GetResponse();

            using (var stream = resp.GetResponseStream())
            {
                using (var sReader = new StreamReader(stream))
                {
                    string responsedJson = sReader.ReadToEnd();
                    sReader.Close();
                   
                    // Пытаемся загрузить все, что ему прислали
                    try
                    {
                        var currentUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responsedJson);
                        DownloadAll(currentUpdate);
                        ////
                        // _updateID = update.UpdateId + 1; — пока пусть будет закоменчено, чтобы не очищать эвенты
                        // здесь будем обрабатывать или класть в очередь
                    }
                    catch
                    {
                        Console.WriteLine("Fail");
                    }

                }
            }

            Console.ReadLine();
        }


        void DownloadAll(Response botResponcse)
        {
            int i = 0;
            foreach (var update in botResponcse.Updates)
            {
                _updateID = update.UpdateId;
                Console.WriteLine(update.Message.Text);
                try
                {
                    using (WebResponse responce = WebRequest.Create(update.Message.Text).GetResponse())
                    {
                        // string format = responce.Headers.GetValues("Content-Type")[0].Split(new char[] { '/' }).Last();
                        string format = Path.GetExtension(update.Message.Text);
                        Console.WriteLine("Format: " + format);
                        var wClient = new WebClient();
                        wClient.DownloadFile(update.Message.Text, "File" + i + "." + format);
                    }
                }
                catch
                {
                    Console.WriteLine("DownloadFailed");
                }
                i++;
                
            }
        }
    }
}