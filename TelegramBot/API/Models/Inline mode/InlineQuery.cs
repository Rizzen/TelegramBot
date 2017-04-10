using Newtonsoft.Json;

namespace TelegramBot.API.Models.Inline_mode
{
    /// <summary>
    /// This object represents an incoming inline query. When the user sends an empty query, your bot could return some default or trending results.
    /// </summary>
    internal class InlineQuery
    {
        /// <summary>
        /// Unique identifier for this query
        /// </summary>
        [JsonProperty("id")]
        internal string Id { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        [JsonProperty("from")]
        internal User From { get; set; }

        /// <summary>
        /// Sender location, only for bots that request user location
        /// </summary>
        [JsonProperty("location")]
        internal Location Location { get; set; }

        /// <summary>
        /// Text of the query (up to 512 characters)
        /// </summary>
        [JsonProperty("query")]
        internal string Query { get; set; }

        /// <summary>
        /// Offset of the results to be returned, can be controlled by the bot
        /// </summary>
        [JsonProperty("offset")]
        internal string Offset { get; set; }

    }
}
