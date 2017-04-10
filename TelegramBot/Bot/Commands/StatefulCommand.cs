using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;

namespace TelegramBot.Bot.Commands
{
    interface ICommandState
    {
        bool ShouldInvoke(TelegramMessageEventArgs input);
        Task<IEnumerable<IReply>> Invoke(TelegramMessageEventArgs input);
    }

    abstract class StatefulCommand : Command
    {
        protected abstract ICommandState CurrentState { get; set; }

        public override bool ShouldInvoke(TelegramMessageEventArgs input)
        {
            return CurrentState.ShouldInvoke(input);
        }

        protected override Task<IEnumerable<IReply>> OnInvoke(TelegramMessageEventArgs input)
        {
            return CurrentState.Invoke(input);
        }
    }
}
