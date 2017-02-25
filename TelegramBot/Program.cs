using System;
using System.IO;
using System.Collections.Generic;
using TelegramBot.NyaBot;

namespace TelegramBot
{
    class Program
    {
        static NyanBot bot = new NyanBot("373376906:AAGaK8bbkmZ_LI9SP_LyLrtRhitieDiXiW8");

        static BotHelper bh = new BotHelper("BaaakaBot");

        static Random random = new Random();

        static MathParser mathParser = new MathParser();

        static DateTime startTime;

        static void Main(string[] args)
        {
            bot.OnMessage += Bot_OnMessage;
            startTime = DateTime.Now;
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

            if (bh.CheckCommand(text, "/roll", "ролл", "roll"))
            {
                if (bh.CheckTime(args.From.Id))
                {
                    bot.SendMessage(args.Message.Chat.Id, random.Next(100).ToString(), args.Message.MessageId);
                }
            }

            if (bh.CheckCommand(text, "рулетка"))
            {
                if (bh.CheckTime(args.From.Id))
                {
                    bot.SendPhoto(args.Message.Chat.Id, @"https://2ch.hk/b/arch/2016-07-15/src/131892994/14686119832660.jpg", replayToMessageId: args.Message.MessageId);
                }
            }

            if (bh.CheckCommand(text, "o_o", "o.o", "о_о"))
            {
                if (bh.CheckTime(args.From.Id))
                {
                    bot.SendSticker(args.Message.Chat.Id, "CAADBAADxgIAAlI5kwbR0EZ_zGfzwQI", args.Message.MessageId);
                }
            }

            if (bh.CheckCommand(text, "аптайм", "/uptime", "uptime"))
            {
                if (bh.CheckTime(args.From.Id))
                {
                    var uptime = DateTime.Now - startTime;

                    bot.SendMessage(args.Message.Chat.Id, uptime.ToString("c"));
                }
            }

            if (bh.CheckCommand(text, "img"))
            {
                var a = bh.GetCommandArgs(text);
                if (a.Length < 1)
                {
                    return;
                }
                bot.SendPhoto(args.Message.Chat.Id, a[0], "", args.Message.MessageId);
            }

            if (bh.CheckCommand(text, "аргументы"))
            {
                var result = bh.GetCommandArgs(text);

                bot.SendMessage(args.Message.Chat.Id, "{" + $"{String.Join(";", result)}" + "}");
            }

            if (bh.CheckCommand(text, "!"))
            {
                if (bh.CheckTime(args.From.Id, 3))
                {
                    MathParser parser = new MathParser();
                    try
                    {
                        var result = mathParser.Evaluate(String.Join(" ", bh.GetCommandArgs(text)));
                        bot.SendMessage(args.Message.Chat.Id, result.ToString(), args.Message.MessageId);
                    }
                    catch (ParserException e)
                    {
                        bot.SendMessage(args.Message.Chat.Id, e.Message, args.Message.MessageId);
                    }
                }
            }

            if (bh.CheckCommand(text, "reset", "/reset", "ресет", "сброс"))
            {
                if (bh.CheckTime(args.From.Id, 20))
                {
                    mathParser = new MathParser();
                    bot.SendMessage(args.Message.Chat.Id, "Математический парсер сброшен.");
                }
            }
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
