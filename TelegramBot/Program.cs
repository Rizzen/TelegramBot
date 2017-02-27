using System;
using System.Threading.Tasks;
using System.Text;

using TelegramBot.NyaBot;
using TelegramBot.NyaBot.Args;
using Newtonsoft.Json;

namespace TelegramBot
{
    class Program
    {
        static NyanBot bot = new NyanBot("TOKEN");

        static BotHelper bh = new BotHelper("BaaakaBot");

        static Random random = new Random();

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

        static void Bot_OnMessage(TelegramMessageEventArgs a)
        {
            if (a.Message.Text == null)
            {
                return;
            }

            string text = a.Message.Text;
            Console.WriteLine(text);

            if (bh.CheckCommand(text, "/roll", "ролл", "roll"))
            {
                if (bh.CheckTime(a.From.Id))
                {
                    int max = 100;
                    var ar = bh.GetCommandArgs(text);
                    if (ar.Length > 0)
                    {
                        int o;
                        if (Int32.TryParse(ar[0], out o))
                        {
                            max = Math.Abs(o);
                        }
                    }
                    int result = random.Next(max + 1);
                    bot.SendMessage(a.ChatId, result.ToString(), a.MessageId);
                }
            }

            if (bh.CheckCommand(text, "рулетка"))
            {
                if (bh.CheckTime(a.From.Id))
                {
                    bot.SendPhoto(a.ChatId, @"https://2ch.hk/b/arch/2016-07-15/src/131892994/14686119832660.jpg", replayToMessageId: a.MessageId);
                }
            }

            if (bh.CheckCommand(text, "o_o", "o.o", "о_о"))
            {
                if (bh.CheckTime(a.From.Id))
                {
                    bot.SendSticker(a.ChatId, "CAADBAADxgIAAlI5kwbR0EZ_zGfzwQI", a.MessageId);
                }
            }

            if (bh.CheckCommand(text, "аптайм", "/uptime", "uptime"))
            {
                if (bh.CheckTime(a.From.Id))
                {
                    var uptime = DateTime.Now - startTime;

                    bot.SendMessage(a.ChatId, uptime.ToString("c"));
                }
            }

            if (bh.CheckCommand(text, "img"))
            {
                var ar = bh.GetCommandArgs(text);
                if (ar.Length < 1)
                {
                    return;
                }
                bot.SendPhoto(a.ChatId, ar[0], "", a.MessageId);
            }

            if (bh.CheckCommand(text, "аргументы"))
            {
                var result = bh.GetCommandArgs(text);

                bot.SendMessage(a.ChatId, "{" + $"{String.Join(";", result)}" + "}");
            }

            if (bh.CheckCommand(text, "!"))
            {
                if (bh.CheckTime(a.From.Id, 3))
                {
                    string result = String.Empty;
                    using (var table = new System.Data.DataTable())
                    {
                        try
                        {
                            result = table.Compute(String.Join(" ", bh.GetCommandArgs(text)), String.Empty).ToString();
                            bot.SendMessage(a.ChatId, result, a.MessageId);
                        }
                        catch
                        {
                            bot.SendMessage(a.ChatId, "Ошибка!", a.MessageId);
                        }
                    }
                }
            }

            if (bh.CheckCommand(text, "сосач", "2ch", @"/2ch", "двач") && bh.CheckTime(a.From.Id))
            {
                var arg = "b";
                var ar = bh.GetCommandArgs(text);
                if (ar.Length > 0)
                {
                    arg = ar[0].Replace("/", "").Replace(".", "").Replace(";", "");
                }

                var sosach = new Sosach();
                var list = sosach.GetThreadsList(arg);
                bot.SendMessage(a.ChatId, (list.Length > 0) ? list : "Ошибка!");
            }

            if (bh.CheckCommand(text, "тест"))
            {
                bot.SendChatAction(a.ChatId, NyaBot.Types.ChatAction.UploadPhoto);
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
