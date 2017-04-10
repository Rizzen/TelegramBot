using Newtonsoft.Json;

namespace TelegramBot.API.Models
{
    /// <summary>
    /// This object contains information about one member of the chat.
    /// </summary>
    internal class ChatMember
    {
        /// <summary>
        /// Information about the user
        /// </summary>
        [JsonProperty("user")]
        internal User User { get; set; }

        /// <summary>
        /// The member's status in the chat. Can be “creator”, “administrator”, “member”, “left” or “kicked”
        /// </summary>
        [JsonProperty("status")]
        internal string Status { get; set; }
    }
}
