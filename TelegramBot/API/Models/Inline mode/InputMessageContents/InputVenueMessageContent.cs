using Newtonsoft.Json;

namespace TelegramBot.API.Models.Inline_mode.InputMessageContents
{
    internal class InputVenueMessageContent: InputMessageContent
    {
        //Latitude of the venue in degrees
        [JsonProperty("latitude")]
        internal float Latitude { get; set; }

        //Longitude of the venue in degrees
        [JsonProperty("longitude")]
        internal float Longtitude { get; set; }

        //Name of the venue
        [JsonProperty("title")]
        internal string Title { get; set; }

        //Address of the venue
        [JsonProperty("address")]
        internal string Address { get; set; }

        //Optional. Foursquare identifier of the venue, if known
        [JsonProperty("foursquare_id")]
        internal string FoursquareId { get; set; }

    }
}
