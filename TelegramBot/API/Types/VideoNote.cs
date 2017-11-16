using Newtonsoft.Json;

namespace TelegramBot.API.Types
{
    /// <summary>
    /// This object represents a video message (available in Telegram apps as of v.4.0).
    /// </summary>
    internal class VideoNote
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        [JsonProperty("file_id")]
        internal string FileId { get; set; }

        /// <summary>
        /// Video width and height as defined by sender
        /// </summary>
        [JsonProperty("length")]
        internal int Lenght { get; set; }

        /// <summary>
        /// Duration of the video in seconds as defined by sender
        /// </summary>
        [JsonProperty("duration")]
        internal int Duration { get; set; }

        /// <summary>
        /// Optional. Video thumbnail
        /// </summary>
        [JsonProperty("thumb")]
        internal PhotoSize Thumb { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        [JsonProperty("file_size")]
        internal int FileSize { get; set; }
    }
}
