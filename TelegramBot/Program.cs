using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ninject;
using Ninject.Syntax;
using TelegramBot.API;
using TelegramBot.Bot;
using TelegramBot.Bot.Updates;
using TelegramBot.Logging;

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

            /*IResolutionRoot kernel = new StandardKernel();
            var types = Assembly.GetExecutingAssembly().GetTypes()
                                                       .Where(t => typeof(ConsoleLogger).IsAssignableFrom(t))
                                                       .ToList();
            foreach (var type in types)
            {
                var myVar = (ConsoleLogger)kernel.Get(type);
                Console.WriteLine(myVar.ToString());
            }*/


            Console.ReadLine();
        }

    }
}
