using Newtonsoft.Json;

namespace TelegramBot.API.Models.Inline_mode
{
    /// <summary>
    /// Represents a result of an inline query that was chosen by the user and sent to their chat partner
    /// </summary>
    internal class ChosenInlineResult
    {
        /// <summary>
        /// The unique identifier for the result that was chosen
        /// </summary>
        [JsonProperty("result_id")]
        internal string ResultId { get; set; }

        /// <summary>
        /// The user that chose the result
        /// </summary>
        [JsonProperty("from")]
        internal User From { get; set; }

        /// <summary>
        /// Sender location, only for bots that require user location
        /// </summary>
        [JsonProperty("location")]
        internal Location Location { get; set; }

        /// <summary>
        /// Identifier of the sent inline message. Available only if there is an inline keyboard attached to the message. 
        /// Will be also received in callback queries and can be used to edit the message.
        /// </summary>
        [JsonProperty("inline_message_id")]
        internal string InlineMessageId { get; set; }

        /// <summary>
        /// The query that was used to obtain the result
        /// </summary>
        [JsonProperty("Query")]
        internal string Query { get; set; }
    }
}
