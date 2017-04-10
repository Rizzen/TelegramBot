using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;
using TelegramBot.Util;

namespace TelegramBot.Bot.Commands
{
    class RollCommand : Command
    {
        private static Random _random = new Random();
        
        public override bool ShouldInvoke(TelegramMessageEventArgs input)
        {
            return MessageEquals(input, "ролл", "roll", "/roll");
        }

        protected override Task<IEnumerable<IReply>> OnInvoke(TelegramMessageEventArgs input)
        {
            return FromResult(new TextReply(_random.Next(0, 101).ToString()));
        }
    }
}
