using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ninject;
using TelegramBot.API;
using TelegramBot.API.WebHook;
using TelegramBot.Bot;
using TelegramBot.Bot.Commands;
using TelegramBot.Bot.Replies;
using TelegramBot.Bot.Updates;
using TelegramBot.Logging;
using Microsoft.Owin.Hosting;
using Owin;
using System.Web.Http;

namespace TelegramBot
{
    public class Program
    {
        public static void Main()
        {
            var api = new ApiClient("437367398:AAEE6VZNK7LOEBcyJiKpR2_o6LMGGUSTyV8");
            var bot = new BotImpl(api, new UpdateProvider(api), new CommandInvoker(new StandardKernel()), new ReplySender(api));
            bot.SendMessage("test", 128055968);
            //Task.WaitAll(bot.Start());
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


            //using (WebApp.Start<Startup>("https://+:8443"))
            //{

            //}

            //var a = await api.SendRequestAsync<WebhookInfo>("getWebhookInfo", null);

            //Console.WriteLine(a.Url);
            Console.ReadLine();
        }

    }

    //public class Startup
    //{
    //    public void Configuration(IAppBuilder app)
    //    {
    //        var config = new HttpConfiguration();

    //        config.Routes.MapHttpRoute("WebHook", "{controller}");

    //        app.Use(config);
    //    }
    //}
}
