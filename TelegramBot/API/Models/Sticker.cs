using Newtonsoft.Json;

namespace TelegramBot.API.Models
{
    /// <summary>
    /// This object represents a sticker.
    /// </summary>
    internal class Sticker
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        [JsonProperty("file_id")]
        internal string FileId { get; set; }

        /// <summary>
        /// Sticker width
        /// </summary>
        [JsonProperty("width")]
        internal int Width { get; set; }

        /// <summary>
        /// Sticker height
        /// </summary>
        [JsonProperty("height")]
        internal int Height { get; set; }

        /// <summary>
        /// Optional. Sticker thumbnail in .webp or .jpg format
        /// </summary>
        [JsonProperty("thumb")]
        internal PhotoSize Thumb { get; set; }

        /// <summary>
        /// Optional. Emoji associated with the sticker
        /// </summary>
        [JsonProperty("emoji")]
        internal string Emoji { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        [JsonProperty("file_size")]
        internal int FileSize { get; set; }
    }
}
