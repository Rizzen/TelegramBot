using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramBot.API.Args;
using TelegramBot.Bot.Replies;

namespace TelegramBot.Bot.Commands
{
    public abstract class Command
    {
        //Abstract methods
        public abstract bool ShouldInvoke(TelegramMessageEventArgs args);

        public abstract Task<IEnumerable<IReply>> OnInvoke(TelegramMessageEventArgs input);


        public async Task<IEnumerable<IReply>> Invoke(TelegramMessageEventArgs args)
        {
            //There can be placed special invoke logic
            IEnumerable<IReply> result = await OnInvoke(args);
            return result;
        }
    }
}
