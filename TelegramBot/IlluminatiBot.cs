using System;
using System.IO;
using System.Net;
using System.Threading;
using TelegramBot.API.Models;

namespace TelegramBot
{
    class IlluminatiBot
    {
        const string Token = @"334103433:AAEc9KxmTjbTyzjK2DFpcuWUeUwQIPBKOi8";
        const string Uri = @"https://api.telegram.org/bot";

        private int _updateId = 0;


        public IlluminatiBot()
        {
            while (true)
            {
                GetUpdates();
                Thread.Sleep(1000);
            }
        }

        void GetUpdates()
        {
            Console.WriteLine($"Обновление: {_updateId}");
            var req = (HttpWebRequest)WebRequest.Create($"{Uri}{Token}/getUpdates?offset={_updateId}");
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
                        Console.WriteLine("--------------Downloads Complete------------");
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
                _updateId = update.UpdateId;
                Console.WriteLine(update.Message.Text);
                try
                {
                    using (WebResponse responce = WebRequest.Create(update.Message.Text).GetResponse())
                    {
                        string format = Path.GetExtension(update.Message.Text);
                        Console.WriteLine($"Format: {format}");
                        var wClient = new WebClient();
                        wClient.DownloadFile(update.Message.Text,$"File {i}{format}");
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
