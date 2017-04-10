using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;
using TelegramBot.Util;

namespace TelegramBot.Bot.Commands
{
    class GifCommand : Command
    {
        private static readonly Random _random = new Random();

        public override bool ShouldInvoke(TelegramMessageEventArgs input)
        {
            OneRequestPer(TimeSpan.FromSeconds(5));
            return MessageEquals(input, "gif", "гифочку", "гифку", "гиф");
        }

        protected override async Task<IEnumerable<IReply>> OnInvoke(TelegramMessageEventArgs input)
        {
            int poolSize = 6393;
            int index = _random.Next(poolSize) + 1;
            byte[] gif = await GetGif(index);
            return new VideoReply(gif).Yield();

        }

        private async Task<byte[]> GetGif(int index)
        {
            using (var client = new WebClient())
            {
                string json = await client.DownloadStringTaskAsync($"http://gifbase.com/gif/{index}?format=json");
                var gifUrl = JToken.Parse(json).Value<string>("url");
                return await client.DownloadDataTaskAsync(gifUrl);
            }
        }
    }
}
