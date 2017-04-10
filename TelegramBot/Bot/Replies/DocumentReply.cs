using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Bot.Replies
{
    public class DocumentReply : IReply
    {
        public byte[] Document { get; }

        public DocumentReply(byte[] document)
        {
            Document = document;
        }

        public TResult AcceptVisitor<TArgs, TResult>(IReplyVisitor<TArgs, TResult> visitor, TArgs args)
        {
            return visitor.VisitDocument(this, args);
        }
    }
}
