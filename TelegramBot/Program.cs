using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using TelegramBot.NyaBot;

namespace TelegramBot
{
    class Program
    {
        static NyanBot bot = new NyanBot("373376906:AAGXeTC9z33E6tH6-cRv2Sml0DnaviY67So");
        static Random random = new Random();
        static readonly Dictionary<int, int> lastMessageTimeDb = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            bot.OnMessage += Bot_OnMessage;
            bot.Start();

            //SimpleBot maBot = new SimpleBot();
            //maBot.updateMessage += MaBot_updateMessage;
            //maBot.StartBot();
        }

        static void Bot_OnMessage(TelegramMessageEventArgs args)
        {
            if (args.Message.Text == null)
            {
                return;
            }

            string text = args.Message.Text;
            Console.WriteLine(text);

            if (text == "/roll" || text == "/ролл" || text == "ролл" || text == "roll")
            {
                if (IsCommandAllowed(args.From.Id, args.Message.Date))
                {
                    bot.SendMessage(args.Message.Chat.Id, random.Next(100).ToString(), args.Message.MessageId);
                }
            }

            if (text == "рулетка" || text == "/рулетка")
            {
                if (IsCommandAllowed(args.From.Id, args.Message.Date))
                {
                    bot.SendPhoto(args.Message.Chat.Id, @"https://2ch.hk/b/arch/2016-07-15/src/131892994/14686119832660.jpg", replayToMessageId: args.Message.MessageId);
                }
            }

            if (text == "o_o" || text == "o.o" || text == "о_о")
            {
                //CAADBAADxgIAAlI5kwbR0EZ_zGfzwQI
                if (IsCommandAllowed(args.From.Id, args.Message.Date))
                {
                    bot.SendSticker(args.Message.Chat.Id, "CAADBAADxgIAAlI5kwbR0EZ_zGfzwQI", args.Message.MessageId);
                }
            }
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

		//private static void MaBot_updateMessage(string message)
  //      {
  //          Console.Write("Message received\n");
  //          if (message.StartsWith("http"))
  //          {
  //              string format;
  //              if ((format = Path.GetExtension(message)) != null)
  //              {
  //                  DownloadFilesOnUri(message);
  //              }
  //          }
  //      }

  //      private static void DownloadFilesOnUri(string message)
  //      {
  //          using (var wClient = new WebClient())
  //          {
  //              try
  //              {
  //                  string nameOfFile = Path.GetFileName(message);
  //                  Console.WriteLine($"Downloaded {nameOfFile}. \nOf the message {message}\n");
  //                  wClient.DownloadFile(message, nameOfFile);
  //              }
  //              catch (Exception e)
  //              {
  //                  Console.WriteLine($"DownloadFailed||Exception:{e.Message}");
  //              }
  //          }
  //      }

    }
}
