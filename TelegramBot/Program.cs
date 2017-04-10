using System;
using System.Threading.Tasks;
using Ninject;
using TelegramBot.API.Models;
using TelegramBot.Bot;
using TelegramBot.IoC;

namespace TelegramBot
{
    class Program
    {
        private static readonly IKernel Kernel = CreateKernel();

        private static IKernel CreateKernel()
        {
            return new StandardKernel(new IoCBindings());
        }

        static void Main(string[] args)
        {
            var bot = Kernel.Get<IBot>();
            Task.WaitAll(bot.Start());
        }
    }
}
