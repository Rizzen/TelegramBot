using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Bot.Replies
{
    public interface IReplySender
    {
        Task Send(IReply reply, long chatId);
    }
}
