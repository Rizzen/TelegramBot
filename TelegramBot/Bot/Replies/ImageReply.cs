using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Bot.Replies
{
    public class ImageReply: IReply
    {
        public byte[] Image { get; }
        public string Caption { get; }

        public ImageReply(byte[] image, string caption = null)
        {
            Image = image;
            Caption = caption;
        }

        public TResult AcceptVisitor<TArgs, TResult>(IReplyVisitor<TArgs, TResult> visitor, TArgs args)
        {
            return visitor.VisitImage(this, args);
        }
    }
}
