using System;
using System.IO;
using System.Net;
using TelegramBot.API_Classes;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleBot maBot = new SimpleBot();
            maBot.updateMessage += MaBot_updateMessage;
            maBot.StartBot();
        }
        private static void MaBot_updateMessage(string message)
        {
            if (message.StartsWith("http"))
            {
                string format;
                if ((format = Path.GetExtension(message)) != null)
                {
                    DownloadFilesOnUri(message);
                }
            }
        }
        private static void DownloadFilesOnUri(string message)
        {
            try
            {
                using (var wClient = new WebClient())
                {
                    string nameOfFile = Path.GetFileName(message);
                    Console.WriteLine($"Downloaded {nameOfFile}. \nOf the message {message}\n");
                    wClient.DownloadFile(message, nameOfFile);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"DownloadFailed||Exception:{e.Message}");
            }
        }
    }
}
