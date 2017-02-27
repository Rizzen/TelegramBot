using System;
using Newtonsoft.Json;

namespace TelegramBot.NyaBot.Types
{
    internal class MessageToSend
    {
        [JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("reply_to_message_id")]
        public int ReplayToMessageId { get; set; }
    }
}
