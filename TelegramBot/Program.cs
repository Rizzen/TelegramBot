using System;

using TelegramBot.NyaBot;
using TelegramBot.NyaBot.Args;

namespace TelegramBot
{
    class Program
    {
        // сюда нужно вставить токен. Свой я больше не буду распространять, потому что этим 
        // можно воспользоваться для бана моего аккаунта
        static NyanBot bot = new NyanBot("TOKEN");

        // хелпер с ником моего бота
        static BotHelper bh = new BotHelper("BaaakaBot");

        // глобальный рандом
        static Random random = new Random();

        static DateTime startTime;

        static void Main(string[] args)
        {
        	Logger.Init(true, false);
            bot.OnMessage += Bot_OnMessage;
            startTime = DateTime.Now;
            bot.Start();

            // Какая-то хуйня, которая осталась от прошлых ботов. Не буду удалять, вдруг кому-то нужно.
            //SimpleBot maBot = new SimpleBot();
            //maBot.updateMessage += MaBot_updateMessage;
            //maBot.StartBot();
        }

        static void Bot_OnMessage(TelegramMessageEventArgs a)
        {
            // проверка: текстовое ли сообщеине. В дальнейшем нужно определять его тип ещё 
            // во время парсинга в классе бота
            if (a.Message.Text == null)
            {
                return;
            }

            string text = a.Message.Text;
            Console.WriteLine(text);

            // демонстрация команды с аргументами
            if (bh.CheckCommand(text, "/roll", "ролл", "roll") && bh.CheckTime(a.From.Id))
            {
                // ставим стандартное максимальное значение
                int maxValue = 100;

                //получаем список аргументов
                var ar = bh.GetCommandArgs(text);

                // пытаемся разобрать новое значение из первого аргумента, если он есть
                if (ar.Length > 0)
                {
                    int o;
                    if (Int32.TryParse(ar[0], out o))
                    {
                        // число приводим к абсолютному виду, мало ли, что пидор мог ввести
                        maxValue = Math.Abs(o);
                    }
                }
                // тут всё ясно, думаю
                var result = random.Next(maxValue + 1).ToString();
                bot.SendMessage(a.ChatId, result, replyToMessageId: a.MessageId);
            }

            // демонстрация отправки изображения
            if (bh.CheckCommand(text, "рулетка") && bh.CheckTime(a.From.Id))
            {
                bot.SendPhoto(a.ChatId, @"https://2ch.hk/b/arch/2016-07-15/src/131892994/14686119832660.jpg", replyToMessageId: a.MessageId);
            }

            // демонстрация отправки стикера
            if (bh.CheckCommand(text, "o_o", "o.o", "о_о", "о.о") && bh.CheckTime(a.From.Id))
            {
                // магическая строка - это id стикера
                bot.SendSticker(a.ChatId, "CAADBAADxgIAAlI5kwbR0EZ_zGfzwQI", replyToMessageId: a.MessageId);
            }

            if (bh.CheckCommand(text, "аптайм", "/uptime", "uptime") && bh.CheckTime(a.From.Id))
            {
                var uptime = DateTime.Now - startTime;

                bot.SendMessage(a.ChatId, uptime.ToString("c"));
            }

            // команда, которая выводит изображение, которое находится в первом аргументе
            if (bh.CheckCommand(text, "img") && bh.CheckTime(a.From.Id))
            {
                var ar = bh.GetCommandArgs(text);
                if (ar.Length < 1)
                {
                    return;
                }
                bot.SendPhoto(a.ChatId, ar[0], "", replyToMessageId:a.MessageId);
            }

            // демонстрация получения списка аргументов
            if (bh.CheckCommand(text, "аргументы") && bh.CheckTime(a.From.Id, 3))
            {
                var result = bh.GetCommandArgs(text);

                bot.SendMessage(a.ChatId, "{" + $"{String.Join(";", result)}" + "}");
            }

            // калькулятор
            if (bh.CheckCommand(text, "!") && bh.CheckTime(a.From.Id, 3))
            {
                string result = String.Empty;
                using (var table = new System.Data.DataTable())
                {
                    try
                    {
                        result = table.Compute(String.Join(" ", bh.GetCommandArgs(text)), String.Empty).ToString();
                        bot.SendMessage(a.ChatId, result, replyToMessageId: a.MessageId);
                    }
                    catch
                    {
                        bot.SendMessage(a.ChatId, "Ошибка!", replyToMessageId: a.MessageId);
                    }
                }
            }

            // демонстрация клавиатуры
            if (bh.CheckCommand(text, "клава"))
            {
                var kb = new API_Classes.ReplyKeyboardMarkup
                {
                    // клавиатура выглядит как массив строк из кнопок, внутри которых массив кнопок: keyboard[строки], строка[кнопки]
                    Keyboard = new[]
                    {
                        // ряд 1
                        new []
                        {
                            new API_Classes.KeyboardButton
                            {
                                Text = "ролл"
                            },
                            new API_Classes.KeyboardButton
                            {
                                Text = "рулетка"
                            }
                        },
                        // ряд 2
                        new []
                        {
                            new API_Classes.KeyboardButton
                            {
                                Text = "аптайм"
                            },
                            new API_Classes.KeyboardButton
                            {
                                Text = "сосач"
                            }
                        },
                        //ряд 3
                        new []
                        {
                            new API_Classes.KeyboardButton
                            {
                                Text = "скрыть"
                            }
                        }
                    }
                };

                bot.SendMessage(a.ChatId, "Выбирай!", replyMarkup: kb);
            }

            // демонстрация скрытия клавиатуры
            if (bh.CheckCommand(text, "скрыть"))
            {
                var kb = new API_Classes.ReplyKeyboardRemove
                {
                    RemoveKeyboard = true
                };
                bot.SendMessage(a.ChatId, "ок", replyMarkup: kb);
            }

            if (bh.CheckCommand(text, "сосач", "2ch", @"/2ch", "двач") && bh.CheckTime(a.From.Id))
            {
                var arg = "b";
                var ar = bh.GetCommandArgs(text);
                if (ar.Length > 0)
                {
                    // костыльные замены, чтобы не делать запросы на совсем хуйню вместо раздела
                    //arg = ar[0].Replace("/", "").Replace(".", "").Replace(";", "");

                    // пофикшено статическим методом
                    if (Sosach.CheckBoardName(ar[0]))
                    {
                        arg = ar[0];
                    }
                }

                var sosach = new Sosach();
                var list = sosach.GetThreadsList(arg);
                bot.SendMessage(a.ChatId, (list.Length > 0) ? list : "Ошибка!");
            }

            // демонстрация отправки действия бота
            if (bh.CheckCommand(text, "тест") && bh.CheckTime(a.From.Id, 100))
            {
                bot.SendChatAction(a.ChatId, NyaBot.Types.ChatAction.UploadPhoto);
            }

            // для даунов
            if (bh.CheckCommand(text, "ь") && bh.CheckTime(a.From.Id))
            {
                bot.SendMessage(a.ChatId, "http://tsya.ru");
            }
        }

        // ещё один метод, который нахуй тут не нужен, но всё ещё тут
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
