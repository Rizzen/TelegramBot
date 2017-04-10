using Newtonsoft.Json;

namespace TelegramBot.API.Models
{
    
    /// <summary>
    /// Contains information about why a request was unsuccessfull.
    /// </summary>
    internal class ResponseParameters
    {
        /// <summary>
        /// Optional. The group has been migrated to a supergroup with the specified identifier. 
        /// This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. 
        /// But it is smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier.
        /// </summary>
        [JsonProperty("migrate_to_chat_id")]
        internal long MigrateToChatId { get; set; }

        /// <summary>
        /// Optional. In case of exceeding flood control, the number of seconds left to wait before the request can be repeated
        /// </summary>
        [JsonProperty("retry_after")]
        internal int RetryAfter { get; set; }
    }
}
