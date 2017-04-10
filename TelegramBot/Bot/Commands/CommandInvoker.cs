using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Ninject;
using Ninject.Syntax;
using TelegramBot.API;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;

namespace TelegramBot.Bot.Commands
{
    class CommandInvoker : ICommandInvoker
    {
        public ICollection<Command> Commands { get; }

        public CommandInvoker(IResolutionRoot kernel)
        {
            Commands = GetCommands(kernel).ToList();
        }

        public async Task<IEnumerable<IReply>> Invoke(TelegramMessageEventArgs input)
        {
            var result = new List<IReply>();
            foreach (var command in Commands)
            {
                if (!command.ShouldInvoke(input)) continue;
                var output = await command.Invoke(input);
                result.AddRange(output);
            }
            return result;
        }

        private static IEnumerable<Command> GetCommands(IResolutionRoot kernel)
        {
            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(Command).IsAssignableFrom(t) && !t.IsAbstract);
            foreach (var commandType in types)
            {
                yield return (Command)kernel.Get(commandType);
            }
        }
    }
}
