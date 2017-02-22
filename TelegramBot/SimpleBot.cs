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

        public SimpleBot()
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
                        foreach (var current in currentUpdate.Updates)
                        {
                            _updateId = current.UpdateId;
                        }
                        DownloadAll(currentUpdate.Updates);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Fail||{e}");
                    }

                }
            }

            Console.ReadLine();
        }

        void GetMessages(Update[] Updates)
        {
            foreach (var current in Updates)
            {

            }
        }

        /// <summary>
        /// Download all files, that send to bot as uri
        /// </summary>
        /// <param name="Updates">Deserialized massive of object Response</param>
        void DownloadAll(Update[] Updates)
        {
            var wClient = new WebClient();
            foreach (var update in Updates)
            {
                if (!update.Message.Text.StartsWith("http")) //Простая проверка - является ли сообщение сайтом
                {
                    continue;
                }
                string format;
                if ((format = Path.GetExtension(update.Message.Text)) == null)
                {
                    continue;
                }
                try
                {
                    using (WebResponse response = WebRequest.Create(update.Message.Text).GetResponse())
                    {
                        string nameOfFile = Path.GetFileName(update.Message.Text);
                        Console.WriteLine($"Downloaded {nameOfFile}. \nOf the message {update.Message.Text}\n");
                        wClient.DownloadFile(update.Message.Text, nameOfFile);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"DownloadFailed||Exception:{e.Message}");
                }

            }
        }
    }
}