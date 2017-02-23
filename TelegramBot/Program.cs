using System;
using System.IO;
using System.Net;
using TelegramBot.NyaBot;

namespace TelegramBot
{
    class Program
    {
		static NyanBot bot = new NyanBot("373376906:AAHSwXddpbP1M0RdEHaUp64_hOAEZf5sIHI");
		static Random random = new Random();

        static void Main(string[] args)
        {
			bot.OnMessage += Bot_OnMessage;
			bot.Start();

            //SimpleBot maBot = new SimpleBot();
            //maBot.updateMessage += MaBot_updateMessage;
            //maBot.StartBot();
        }

		static void Bot_OnMessage(NyaBot.TelegramMessageEventArgs args)
		{
			if (args.Message.Text == null)
			{
				return;
			}

			string text = args.Message.Text;
			Console.WriteLine(text);

			if (text == "/roll")
			{
				bot.SendPhoto(args.Message.Chat.Id, GetRandomLink(), "", args.Message.MessageId);
			}
		}

		static string GetRandomLink()
		{
			var links = new[]
			{ "http://www.9355.ru/lessons/author/lot/lot5/lot5_img/068.png",
				"https://pp.vk.me/c836331/v836331354/1a767/ZThUwlLlzS8.jpg",
				"https://www.look.com.ua/large/201306/69608.jpg",
				"http://lurkmore.so/images/thumb/2/2b/%D0%97%D0%B0_%D0%B5%D0%B4%D1%83.jpg/180px-%D0%97%D0%B0_%D0%B5%D0%B4%D1%83.jpg"
			};

			return links[random.Next(links.Length)];
		}

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
