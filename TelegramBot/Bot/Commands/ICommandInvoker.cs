using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;

namespace TelegramBot.Bot.Commands
{
    public interface ICommandInvoker
    {
        Task<IEnumerable<IReply>> Invoke(TelegramMessageEventArgs input);
    }
}