using System;
using System.IO;
using System.Net;
//using TelegramBot.NyaBot;

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

		// Не трогайте, пожалуйста
		//static void Bot_OnMessage(NyaBot.TelegramMessageEventArgs args)
		//{
		//	if (args.Message.Text == null)
		//	{
		//		return;
		//	}

		//	string text = args.Message.Text;
		//	Console.WriteLine(text);

		//	if (text.StartsWith("/time", StringComparison.Ordinal))
		//	{
		//		bot.SendMessage(args.Message.Chat.Id, DateTime.Now.ToString());
		//	}
		//	else if (text.StartsWith("/penis", StringComparison.Ordinal))
		//	{
		//		bot.SendMessage(args.Message.Chat.Id, "))))");
		//	}
		//}

		private static void MaBot_updateMessage(string message)
        {
            Console.Write("Message received\n");
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
