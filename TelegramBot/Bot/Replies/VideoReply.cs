using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Bot.Replies
{
    public class VideoReply : IReply
    {
        public VideoReply(byte[] video)
        {
            Video = video;
        }

        public byte[] Video { get; }

        public TResult AcceptVisitor<TArgs, TResult>(IReplyVisitor<TArgs, TResult> visitor, TArgs args)
        {
            return visitor.VisitVideo(this, args);
        }
    }
}
