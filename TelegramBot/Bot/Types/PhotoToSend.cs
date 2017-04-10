using Newtonsoft.Json;

namespace TelegramBot.Bot.Types
{
    internal class PhotoToSend
    {
        [JsonProperty("chat_id")]
        public string ChatId { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("disable_notification")]
        public bool DisableNotification { get; set; }

        [JsonProperty("reply_to_message_id")]
        public int ReplyToMessageId { get; set; }

        [JsonProperty("reply_markup")]
        public object ReplyMarkup { get; set; }
    }
}
