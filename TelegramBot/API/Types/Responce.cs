using Newtonsoft.Json;

namespace TelegramBot.API.Types
{
    internal class Responce
    {
        [JsonProperty("ok")]
        public bool Success { get; set; }

        [JsonProperty("result")]
        public Update[] Updates { get; set; }
    }
}
