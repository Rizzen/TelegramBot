using System;
using System.IO;
using System.Collections.Generic;
using TelegramBot.NyaBot;

namespace TelegramBot
{
    class Program
    {
        static NyanBot bot = new NyanBot("373376906:AAGXeTC9z33E6tH6-cRv2Sml0DnaviY67So");
        static Random random = new Random();
        static readonly Dictionary<int, int> lastMessageTimeDb = new Dictionary<int, int>();
        static DateTime startTime;

        static void Main(string[] args)
        {
            //bot.OnMessage += Bot_OnMessage;
            //startTime = DateTime.Now;
            //bot.Start();

            SimpleBot maBot = new SimpleBot();
            maBot.updateMessage += MaBot_updateMessage;
            maBot.StartBot();
        }

        static void Bot_OnMessage(TelegramMessageEventArgs args)
        {
            if (args.Message.Text == null)
            {
                return;
            }

            string text = args.Message.Text;
            Console.WriteLine(text);

            if (CheckCommand(text, "/roll", "ролл", "roll"))
            {
                if (IsCommandAllowed(args.From.Id, args.Message.Date))
                {
                    bot.SendMessage(args.Message.Chat.Id, random.Next(100).ToString(), args.Message.MessageId);
                }
            }

            if (CheckCommand(text, "рулетка"))
            {
                if (IsCommandAllowed(args.From.Id, args.Message.Date))
                {
                    bot.SendPhoto(args.Message.Chat.Id, @"https://2ch.hk/b/arch/2016-07-15/src/131892994/14686119832660.jpg", replayToMessageId: args.Message.MessageId);
                }
            }

            if (CheckCommand(text, "o_o", "o.o", "о_о"))
            {
                if (IsCommandAllowed(args.From.Id, args.Message.Date))
                {
                    bot.SendSticker(args.Message.Chat.Id, "CAADBAADxgIAAlI5kwbR0EZ_zGfzwQI", args.Message.MessageId);
                }
            }

            if (CheckCommand(text, "аптайм", "/uptime", "uptime"))
            {
                if (IsCommandAllowed(args.From.Id, args.Message.Date))
                {
                    var uptime = DateTime.Now - startTime;

                    bot.SendMessage(args.Message.Chat.Id, uptime.ToString("g"));
                }
            }

            //if (FileDownloader.IsFileLink(text))
            //{
            //    FileDownloader.DownloadFile(text.Trim());
            //}
        }

        static bool CheckCommand(string text, params string[] args)
        {
            foreach (var s in args)
            {
                if (s.StartsWith(text, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }

        static bool IsCommandAllowed(int userId, int timestamp)
        {
            if (!lastMessageTimeDb.ContainsKey(userId))
            {
                lastMessageTimeDb.Add(userId, timestamp);
                return true;
            }

            if ((timestamp - lastMessageTimeDb[userId]) < 10)
            {
                return false;
            }

            lastMessageTimeDb[userId] = timestamp;
            return true;
        }

		private static void MaBot_updateMessage(string message)
        {
            Console.Write("Message received\n");

            FileDownloader downloaderMaBot = new FileDownloader();
            if(downloaderMaBot.IsFileLink(message))
            {
                downloaderMaBot.DownloadFile(message);
            }
        }
    }
}
