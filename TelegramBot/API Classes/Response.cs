using Newtonsoft.Json;

namespace TelegramBot.API_Classes
{
    internal class Response
    {
        [JsonProperty("ok")]
        public bool Success { get; set; }

        [JsonProperty("result")]
        public Update[] Updates { get; set; }
    }
}
