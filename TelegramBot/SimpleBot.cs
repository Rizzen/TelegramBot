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

        private int _updateId = 0;

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
            Console.WriteLine("Обновление: {0}", _updateId);
            var req = (HttpWebRequest)WebRequest.Create(URI + TOKEN + "/getUpdates" + "?offset="+ (_updateId + 1));
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
                        foreach (var current in currentUpdate.Updates)
                        {
                            _updateId = current.UpdateId;
                        }
                        DownloadAll(currentUpdate.Updates);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"Fail||{e}");
                    }

                }
            }

            Console.ReadLine();
        }

        void GetMessages(Update[] Updates)
        {
            foreach(var current in Updates)
            {

            }
        }

        void DownloadAll(Update[] Updates)
        {
            int i = 0;
            foreach (var update in Updates)
            {
                try
                {
                    if (update.Message.Text.Contains("https")) //Простая проверка - является ли сообщение сайтом
                    {
                        using (WebResponse response = WebRequest.Create(update.Message.Text).GetResponse())
                        {
                            string format = Path.GetExtension(update.Message.Text);
                            if (format != null)
                            {
                                Console.WriteLine($"Format{format} of the message {update.Message.Text}");
                                var wClient = new WebClient();
                                wClient.DownloadFile(update.Message.Text, $"File_{i}{format}");
                                i++; // Если случится ошибка, то здесь номер не увеличится, ибо ничего не скачается
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("DownloadFailed||Exception:{0}", e);
                }
                
            }
        }
    }
}