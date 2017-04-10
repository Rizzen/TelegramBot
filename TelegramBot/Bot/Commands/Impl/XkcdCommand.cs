using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;
using TelegramBot.Util;

namespace TelegramBot.Bot.Commands
{
    class XkcdCommand : Command
    {
        

        public override bool ShouldInvoke(TelegramMessageEventArgs input)
        {
            return MessageEquals(input, "xkcd");
        }

        protected override async Task<IEnumerable<IReply>> OnInvoke(TelegramMessageEventArgs input)
        {
            return (await GetRandomXkcd()).Yield();
        }

        private async Task<ImageReply> GetRandomXkcd()
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                var html = await client.DownloadStringTaskAsync("http://xkcd.ru/random/");
                var document = new HtmlDocument();
                document.LoadHtml(html);

                string imageUrl = document.QuerySelector(".main > a:nth-child(6) > img:nth-child(1)").Attributes["src"].Value;
                string description = document.QuerySelector(".main > h1:nth-child(3)")?.InnerText;
                byte[] data = await client.DownloadDataTaskAsync(imageUrl);
                return new ImageReply(data, description);

            }
        }
    }
}
