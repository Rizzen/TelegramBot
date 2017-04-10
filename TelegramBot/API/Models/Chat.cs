using Newtonsoft.Json;

namespace TelegramBot.API.Models
{
    /// <summary>
    /// This object represents a chat.
    /// </summary>
    internal class Chat
    {
        /// <summary>
        /// Unique identifier for this chat. 
        /// This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. 
        /// But it smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier.
        /// </summary>
        [JsonProperty("id")]
        internal long Id { get; set; }

        /// <summary>
        /// Type of chat, can be either “private”, “group”, “supergroup” or “channel”
        /// </summary>
        [JsonProperty("type")]
        internal string Type { get; set; }

        /// <summary>
        /// Optional. Title, for supergroups, channels and group chats
        /// </summary>
        [JsonProperty("title")]
        internal string Title { get; set; }

        /// <summary>
        /// Optional. Username, for private chats, supergroups and channels if available
        /// </summary>
        [JsonProperty("username")]
        internal string Username { get; set; }

        /// <summary>
        /// Optional. First name of the other party in a private chat
        /// </summary>
        [JsonProperty("first_name")]
        internal string FirstName { get; set; }

        /// <summary>
        /// Optional. Last name of the other party in a private chat
        /// </summary>
        [JsonProperty("last_name")]
        internal string LastName { get; set; }

        /// <summary>
        /// Optional. True if a group has ‘All Members Are Admins’ enabled.
        /// </summary>
        [JsonProperty("all_members_are_administrators")]
        internal bool AllMembersAreAdministrators { get; set; }

    }
}
