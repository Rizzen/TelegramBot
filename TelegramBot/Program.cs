using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TelegramBot.API;
using TelegramBot.Bot;
using TelegramBot.Bot.Updates;

namespace TelegramBot
{
    class Program
    {
        static void Main()
        {
            var api = new ApiClient("437367398:AAEE6VZNK7LOEBcyJiKpR2_o6LMGGUSTyV8");
            var bot = new BotImpl(api, new UpdateProvider(api));
            Task.WaitAll(bot.Start());
            //var simpleBot = new SimpleBot();
            //simpleBot.StartBot();
        }

    }
}
