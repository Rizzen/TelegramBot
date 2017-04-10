using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ninject;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;
using TelegramBot.Logging;
using TelegramBot.Util;

namespace TelegramBot.Bot.Commands
{
    class CatCommand : Command
    {
        [Inject]
        public ILogger Logger { get; set; }

        public override bool ShouldInvoke(TelegramMessageEventArgs input)
        {
            OneRequestPer(TimeSpan.FromSeconds(5));
            return input?.Message?.Text?.ToUpper().Contains("КОТ") ?? false;
        }

        protected override async Task<IEnumerable<IReply>> OnInvoke(TelegramMessageEventArgs input)
        {
            byte[] image;
            try
            {
                image = await GetRandomCatImage();
            }
            catch (WebException ex)
            {
                Logger.Log(ex);
                return Nothing;
            }

            return new IReply[]
            {
                new ImageReply(image, "Кто-то сказал " + FindCatWord(input.Message.Text) + "???")
            };
        }

        private static Task<byte[]> GetRandomCatImage()
        {
            using (var client = new WebClient())
            {
                return client.DownloadDataTaskAsync("http://thecatapi.com/api/images/get");
            }
        }

        private string FindCatWord(string input)
        {
            string[] words = input.Split(' ', ',', ':', ';', '(', ')', '[', ']');
            foreach (var word in words)
            {
                if (word.ToUpper().Contains("КОТ"))
                {
                    return Regex.Replace(word, "кот", "КОТ", RegexOptions.IgnoreCase);
                }
            }

            return null;
        }

        protected override string GetOverThrottleText(TimeSpan remainingTime)
        {
            return "Прости, следующий котик будет только через " + remainingTime.ToHmsString();
        }
    }
}
