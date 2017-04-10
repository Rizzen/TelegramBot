using Newtonsoft.Json;

namespace TelegramBot.API.Models
{
    /// <summary>
    /// This object represents a general file (as opposed to photos, voice messages and audio files).
    /// </summary>
    internal class Document
    {
        /// <summary>
        /// Unique file identifier
        /// </summary>
        [JsonProperty("file_id")]
        internal string FileId { get; set; }

        /// <summary>
        /// Optional. Document thumbnail as defined by sender
        /// </summary>
        [JsonProperty("thumb")]
        internal PhotoSize Thumb { get; set; }

        /// <summary>
        /// Optional. Original filename as defined by sender
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
