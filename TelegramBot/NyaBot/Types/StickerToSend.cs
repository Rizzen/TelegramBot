using System;
using Newtonsoft.Json;

namespace TelegramBot.NyaBot.Types
{
    internal class StickerToSend
    {
        [JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [JsonProperty("sticker")]
        public string Sticker { get; set; }

        [JsonProperty("reply_to_message_id")]
        public int ReplayToMessageId { get; set; }
    }
}
