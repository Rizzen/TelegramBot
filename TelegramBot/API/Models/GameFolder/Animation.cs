using Newtonsoft.Json;

namespace TelegramBot.API.Models.GameFolder
{
    /// <summary>
    /// You can provide an animation for your game so that it looks stylish in chats (check out Lumberjack for an example). 
    /// This object represents an animation file to be displayed in the message containing a game.
    /// </summary>
    internal class Animation
    {
        /// <summary>
        /// Unique file identifier
        /// </summary>
        [JsonProperty("file_id")]
        internal string FileId { get; set; }

        /// <summary>
        /// Optional. Animation thumbnail as defined by sender
        /// </summary>
        [JsonProperty("thumb")]
        internal PhotoSize Thumb { get; set; }

        /// <summary>
        /// Optional. Original animation filename as defined by sender
        /// </summary>
        [JsonProperty("file_name")]
        internal string FileName { get; set; }

        /// <summary>
        /// Optional. MIME type of the file as defined by sender
        /// </summary>
        [JsonProperty("mime_type")]
        internal string MimeType { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        [JsonProperty("file_size")]
        internal int FileSize { get; set; }
    }
}
