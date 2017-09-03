using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Bot.Replies
{
    interface IReply
    {
        TResult AcceptVisitor<TArgs, TResult>(IReplyVisitor<TArgs, TResult> visitor, TArgs args);
    }
}
