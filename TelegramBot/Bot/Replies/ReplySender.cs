using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.API;
using TelegramBot.Bot.Types;

namespace TelegramBot.Bot.Replies
{
    internal class ReplySender: IReplyVisitor<long, Task>, IReplySender
    {
        private readonly ApiClient _client;

        public ReplySender(ApiClient api)
        {
            _client = api;
        }

        public Task Send(IReply reply, long chatId)
        {
            return reply.AcceptVisitor(this, chatId);
        }

        public Task VisitText(TextReply reply, long chatId)
        {
            return _client.SendRequestAsync<object>("send_message", new MessageToSend
            {
                ChatId = chatId.ToString(),
                DisableNotification = false,
                DisableWebPagePreview = false,
                ReplyToMessageId = 0,
                ReplyMarkup = null
            });
        }

        public Task VisitImage(ImageReply reply, long chatId)
        {
            return _client.SendPhoto<object>(chatId, reply.Image);
        }

        public Task VisitVideo(VideoReply reply, long chatId)
        {
            return _client.SendVideo<object>(chatId, reply.Video);
        }

        public Task VisitButtons(ButtonsReply reply, long chatId)
        {
            return _client.SendRequestAsync<object>("sendMessage", new MessageToSend
            {
                ChatId = chatId.ToString(),
                DisableNotification = false,
                DisableWebPagePreview = false,
                ReplyToMessageId = 0,
                ReplyMarkup = reply.Markup
            });
        }

        public Task VisitDocument(DocumentReply reply, long chatId)
        {
            return _client.SendDocument<object>(chatId, reply.Document);
        }

    }
}
