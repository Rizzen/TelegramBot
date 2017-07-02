using Newtonsoft.Json;

namespace TelegramBot.API
{
    internal class Responce
    {
        [JsonProperty("ok")]
        public bool Success { get; set; }

        [JsonProperty("result")]
        public Update[] Updates { get; set; }
    }
}
