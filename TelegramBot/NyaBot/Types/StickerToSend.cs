using Newtonsoft.Json;

namespace TelegramBot.NyaBot.Types
{
    internal class StickerToSend
    {
        [JsonProperty("chat_id")]
        public string ChatId { get; set; }

        [JsonProperty("sticker")]
        public string Sticker { get; set; }

        [JsonProperty("disable_notification")]
        public bool DisableNotification { get; set; }

        [JsonProperty("reply_to_message_id")]
        public int ReplyToMessageId { get; set; }

        [JsonProperty("reply_markup")]
        public object ReplyMarkup { get; set; }
    }
}
