using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using RestSharp.Extensions.MonoHttp;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;
using TelegramBot.Util;

namespace TelegramBot.Bot.Commands
{
    class AnekdotCommand : Command
    {
        public override bool ShouldInvoke(TelegramMessageEventArgs input)
        {
            return MessageEquals(input, "anek", "анекдот", "анек");
        }

        protected override async Task<IEnumerable<IReply>> OnInvoke(TelegramMessageEventArgs input)
        {
            string anekdot = await Task.Run(()=> GetAnekdot());
            string decoded = HttpUtility.HtmlDecode(anekdot); //no idea if required
            return new TextReply(decoded).Yield();
        }

        private string GetAnekdot()
        {
            string url = "https://www.anekdot.ru/random/anekdot/";
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            var doc = web.Load(url);
            return doc.QuerySelector("div.topicbox:nth-child(2) > div:nth-child(2)").InnerText;
        }
    }
}
