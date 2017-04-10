using Newtonsoft.Json;

namespace TelegramBot.Bot.Types
{
    internal class MessageToSend
    {
        [JsonProperty("chat_id")]
        public string ChatId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("disable_web_page_preview")]
        public bool DisableWebPagePreview { get; set; }

        [JsonProperty("disable_notification")]
        public bool DisableNotification { get; set; }

        [JsonProperty("reply_to_message_id")]
        public int ReplayToMessageId { get; set; }

        [JsonProperty("reply_markup")]
        public object ReplyMarkup { get; set; }
    }
}
