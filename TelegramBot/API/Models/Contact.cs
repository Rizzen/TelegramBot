using Newtonsoft.Json;

namespace TelegramBot.API.Models
{
    /// <summary>
    /// This object contains information about one member of the chat.
    /// </summary>
    internal class Contact
    {
        /// <summary>
        /// Contact's phone number
        /// </summary>
        [JsonProperty("phone_number")]
        internal string PhoneNumber { get; set; }

        /// <summary>
        /// Contact's first name
        /// </summary>
        [JsonProperty("first_name")]
        internal string FirstName { get; set; }

        /// <summary>
        /// Optional. Contact's last name
        /// </summary>
        [JsonProperty("last_name")]
        internal string LastName { get; set; }

        /// <summary>
        /// Optional. Contact's user identifier in Telegram
        /// </summary>
        [JsonProperty("user_id")]
        internal int UserId { get; set; }
    }
}
