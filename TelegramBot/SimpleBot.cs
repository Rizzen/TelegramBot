using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                    // Пытаемся загрузить все, что ему прислали
                    try
                    {
                        var currentUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responsedJson);
                        foreach (var update in currentUpdate.Updates)
                        {
                            int i = 0;
                            Console.WriteLine(update.Message.Text);
                            try
                            {
                                using (WebResponse responce = WebRequest.Create(update.Message.Text).GetResponse())
                                {
                                    string format = responce.Headers.GetValues("Content-Type")[0].Split(new char[] { '/' }).Last();
                                    Console.WriteLine("Format: " + format);
                                    var wClient = new WebClient();
                                    wClient.DownloadFile(update.Message.Text, "File" + i + "." + format);

                                }
                                    
                            }
                            catch
                            {
                                Console.WriteLine("DownloadFailed");
                            }

                            ////
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

        //void MakeRequest(string method)
        //{
        //    var req = (HttpWebRequest)WebRequest.Create(URI + TOKEN + method);
        //    var resp = (HttpWebResponse)req.GetResponse();


        //}
    }
}