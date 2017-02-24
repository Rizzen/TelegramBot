using System;
using System.IO;
using System.Net;

namespace TelegramBot
{
    class SimpleBotFunctional
    {
        internal void DownloadFilesOnUri(string message)
        {
            using (var wClient = new WebClient())
            {
                try
                {
                    string nameOfFile = Path.GetFileName(message);
                    Console.WriteLine($"Downloaded {nameOfFile}. \nOf the message {message}\n");
                    wClient.DownloadFile(message, nameOfFile);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"DownloadFailed||Exception:{e.Message}");
                }
            }
        }
    }
}
