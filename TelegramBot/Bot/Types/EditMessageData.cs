using Newtonsoft.Json;

namespace TelegramBot.Bot.Types
{
    internal class EditMessageData
    {
        [JsonProperty("chat_id")]
        public string ChatId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("message_id")]
        public int MessageId { get; set; }

        [JsonProperty("inline_message_id")]
        public string InlineMessageId { get; set; }

        [JsonProperty("disable_web_page_preview")]
        public bool DisableWebPagePreview { get; set; }

        [JsonProperty("reply_markup")]
        public object ReplyMarkup { get; set; }
    }
}
