using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Bot.Replies
{
    internal class ReplySender: IReplyVisitor<long, Task>, IReplySender
    {

        public Task Send(IReply reply, long chatId)
        {
            throw new NotImplementedException();
        }

        public Task VisitText(TextReply reply, long args)
        {
            throw new NotImplementedException();
        }

        public Task VisitImage(ImageReply reply, long args)
        {
            throw new NotImplementedException();
        }

        public Task VisitVideo(VideoReply reply, long args)
        {
            throw new NotImplementedException();
        }

        public Task VisitButtons(ButtonsReply reply, long args)
        {
            throw new NotImplementedException();
        }

        public Task VisitDocument(DocumentReply reply, long args)
        {
            throw new NotImplementedException();
        }

    }
}
