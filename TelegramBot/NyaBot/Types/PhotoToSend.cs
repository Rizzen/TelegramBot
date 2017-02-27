using System;
using Newtonsoft.Json;

namespace TelegramBot.NyaBot.Types
{
    internal class PhotoToSend
    {
        [JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [JsonProperty("photo")]
        public string PhotoUrl { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("reply_to_message_id")]
        public int ReplayToMessageId { get; set; }
    }
}
