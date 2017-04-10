using Newtonsoft.Json;

namespace TelegramBot.Bot.Types
{
    public class ChatActionToSend
    {
        [JsonProperty("chat_id")]
        public string ChatId { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
