using Newtonsoft.Json;

namespace TelegramBot.API.Models
{
    /// <summary>
    /// This object represents a venue.
    /// </summary>
    internal class Venue
    {
        /// <summary>
        /// Venue location
        /// </summary>
        [JsonProperty("location")]
        internal Location Location { get; set; }

        /// <summary>
        /// Name of the venue
        /// </summary>
        [JsonProperty("title")]
        internal string Title { get; set; }

        /// <summary>
        /// Address of the venue
        /// </summary>
        [JsonProperty("address")]
        internal string Address { get; set; }

        /// <summary>
        /// Optional. Foursquare identifier of the venue
        /// </summary>
        [JsonProperty("foursquare_id")]
        internal string FoursquareId { get; set; }
    }
}
