using Newtonsoft.Json;

namespace TelegramBot.API.Models.Inline_mode.InputMessageContents
{
    internal class InputLocationMessageContent: InputMessageContent
    {
        //Latitude of the location in degrees
        [JsonProperty("latitude")]
        internal float Latitude { get; set; }

        //Longitude of the location in degrees
        [JsonProperty("longitude")]
        internal float Longtitude { get; set; }
    }
}
