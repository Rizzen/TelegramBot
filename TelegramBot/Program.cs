using System;

using TelegramBot.NyaBot;
using TelegramBot.NyaBot.Args;

namespace TelegramBot
{
    class Program
    {
        static NyanBot bot = null;
        static BotHelper botHelper = null;
        static Random random = null;
        static DateTime startTime;

        static void Main(string[] args)
        {
        	Logger.Init(true, false);

            bot = new NyanBot("TOKEN");
            botHelper = new BotHelper("BaaakaBot");

            random = new Random();

            bot.OnMessage += Bot_OnMessage;
            bot.OnCallbackQuery += Bot_OnCallbackQuery;

            startTime = DateTime.Now;
            bot.Start();
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
            Logger.LogMessage($"{a.From.Username ?? a.From.Id.ToString()}: {text}");

            // демонстрация команды с аргументами
            if (botHelper.CheckCommand(text, "/roll", "ролл", "roll") && botHelper.CheckTime(a.From.Id))
            {
                // ставим стандартное максимальное значение
                int maxValue = 100;

                //получаем список аргументов
                var ar = botHelper.GetCommandArgs(text);

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
            if (botHelper.CheckCommand(text, "рулетка") && botHelper.CheckTime(a.From.Id))
            {
                bot.SendPhoto(a.ChatId, @"https://2ch.hk/b/arch/2016-07-15/src/131892994/14686119832660.jpg", replyToMessageId: a.MessageId);
            }

            // демонстрация отправки стикера
            if (botHelper.CheckCommand(text, "o_o", "o.o", "о_о", "о.о") && botHelper.CheckTime(a.From.Id))
            {
                // магическая строка - это id стикера
                bot.SendSticker(a.ChatId, "CAADBAADxgIAAlI5kwbR0EZ_zGfzwQI", replyToMessageId: a.MessageId);
            }

            if (botHelper.CheckCommand(text, "аптайм", "/uptime", "uptime") && botHelper.CheckTime(a.From.Id))
            {
                var uptime = DateTime.Now - startTime;

                bot.SendMessage(a.ChatId, uptime.ToString("c"));
            }

            // команда, которая выводит изображение, которое находится в первом аргументе
            if (botHelper.CheckCommand(text, "img") && botHelper.CheckTime(a.From.Id))
            {
                var ar = botHelper.GetCommandArgs(text);
                if (ar.Length < 1)
                {
                    return;
                }
                bot.SendPhoto(a.ChatId, ar[0], "", replyToMessageId:a.MessageId);
            }

            // демонстрация получения списка аргументов
            if (botHelper.CheckCommand(text, "аргументы") && botHelper.CheckTime(a.From.Id, 3))
            {
                var result = botHelper.GetCommandArgs(text);

                bot.SendMessage(a.ChatId, "{" + $"{String.Join(";", result)}" + "}");
            }

            // калькулятор
            if (botHelper.CheckCommand(text, "!") && botHelper.CheckTime(a.From.Id, 3))
            {
                string result = String.Empty;
                using (var table = new System.Data.DataTable())
                {
                    try
                    {
                        result = table.Compute(String.Join(" ", botHelper.GetCommandArgs(text)), String.Empty).ToString();
                        bot.SendMessage(a.ChatId, result, replyToMessageId: a.MessageId);
                    }
                    catch
                    {
                        bot.SendMessage(a.ChatId, "Ошибка!", replyToMessageId: a.MessageId);
                    }
                }
            }

            // демонстрация клавиатуры
            if (botHelper.CheckCommand(text, "клава"))
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

            // демонстрация инлайн кнопок
            if (botHelper.CheckCommand(text, "инлайн"))
            {
                var kb = new API_Classes.InlineKeyboardMarkup
                {
                    InlineKeyboard = new[]
                    {
                        // ряд 1
                        new []
                        {
                            new API_Classes.InlineKeyboardButton
                            {
                                Text = "0",
                                CallbackData = "0"
                            }
                        }
                    }
                };

                bot.SendMessage(a.ChatId, "мяумур", replyMarkup: kb);
            }

            // демонстрация скрытия клавиатуры
            if (botHelper.CheckCommand(text, "скрыть"))
            {
                var kb = new API_Classes.ReplyKeyboardRemove
                {
                    RemoveKeyboard = true
                };
                bot.SendMessage(a.ChatId, "ок", replyMarkup: kb);
            }

            if (botHelper.CheckCommand(text, "сосач", "2ch", @"/2ch", "двач") && botHelper.CheckTime(a.From.Id))
            {
                var arg = "b";
                var ar = botHelper.GetCommandArgs(text);
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
            if (botHelper.CheckCommand(text, "тест") && botHelper.CheckTime(a.From.Id, 100))
            {
                bot.SendChatAction(a.ChatId, NyaBot.Types.ChatAction.UploadPhoto);
            }

            // для даунов
            if (botHelper.CheckCommand(text, "ь") && botHelper.CheckTime(a.From.Id))
            {
                bot.SendMessage(a.ChatId, "http://tsya.ru");
            }
        }

        static void Bot_OnCallbackQuery(CallbackQueryEventArgs a)
        {
            if (a.CallbackQuery.Data == null)
            {
                return;
            }
            int n;
            if (!Int32.TryParse(a.CallbackQuery.Data, out n))
            {
                return;
            }

            var kb = new API_Classes.InlineKeyboardMarkup
            {
                InlineKeyboard = new[]
                {
                    new[]
                    {
                        new API_Classes.InlineKeyboardButton
                        {
                            Text = (n + 1).ToString(),
                            CallbackData = (n + 1).ToString()
                        }
                    }
                }
            };

            bot.EditMessageReplyMarkup(a.CallbackQuery.Message.Chat.Id, a.CallbackQuery.Message.MessageId, replyMarkup: kb);
        }
    }
}
