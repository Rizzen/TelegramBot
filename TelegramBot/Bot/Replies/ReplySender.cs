using System.Threading.Tasks;
using TelegramBot.API;
using TelegramBot.Bot.Types;

namespace TelegramBot.Bot.Replies
{
    class ReplySender : IReplyVisitor<long, Task>, IReplySender
    {
        private readonly ApiClient _client;

        public ReplySender(ApiClient client)
        {
            _client = client;
        }

        public Task Send(IReply reply, long chatId)
        {
            return reply.AcceptVisitor(this, chatId);
        }

        public async Task VisitText(TextReply reply, long chatId)
        {
            await _client.SendRequestAsync<object>("sendMessage", new MessageToSend
            {
                ChatId = chatId.ToString(),
                Text = reply.Text,
                DisableWebPagePreview = false,
                DisableNotification = false,
                ReplayToMessageId = 0,
                ReplyMarkup = null
            });
        }

        public async Task VisitImage(ImageReply reply, long chatId)
        {
            await _client.SendPhoto<object>(chatId, reply.Image, reply.Caption);
                
        }

        public async Task VisitButtons(ButtonsReply reply, long chatId)
        {
            await _client.SendRequestAsync<object>("sendMessage", new MessageToSend
            {
                ChatId = chatId.ToString(),
                Text = reply.Title,
                DisableWebPagePreview = false,
                DisableNotification = false,
                ReplayToMessageId = 0,
                ReplyMarkup = reply.Markup
            });
        }

        public async Task VisitDocument(DocumentReply reply, long chatId)
        {
            await _client.SendDocument<object>(chatId, reply.Document);
        }

        public async Task VisitVideo(VideoReply reply, long chatId)
        {
            await _client.SendVideo<object>(chatId, reply.Video);
        }
    }
}
