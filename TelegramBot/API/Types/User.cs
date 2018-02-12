using Newtonsoft.Json;

namespace TelegramBot.API.Types
{
    public class User
    {
        /// <summary>
        /// Unique identifier for this user or bot
        /// </summary>
        [JsonProperty("id")]
        internal int Id { get; set; }

        /// <summary>
        /// User‘s or bot’s first name
        /// </summary>
        [JsonProperty("first_name")]
        internal string FirstName { get; set; }

        /// <summary>
        /// Optional. User‘s or bot’s last name
        /// </summary>
        [JsonProperty("last_name")]
        internal string LastName { get; set; }

        /// <summary>
        /// Optional. User‘s or bot’s username
        /// </summary>
        [JsonProperty("username")]
        internal string Username { get; set; }

        /// <summary>
        /// Optional. IETF language tag of the user's language
        /// </summary>
        [JsonProperty("language_code")]
        internal string LanguageCode { get; set; }

    }
}
