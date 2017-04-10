using Newtonsoft.Json;

namespace TelegramBot.API.Models
{
    /// <summary>
    /// This object represents an inline keyboard that appears right next to the message it belongs to.
    /// </summary>
    internal class InlineKeyboardMarkup
    {
        /// <summary>
        /// Array of button rows, each represented by an Array of InlineKeyboardButton objects
        /// </summary>
        [JsonProperty("inline_keyboard")]
        internal InlineKeyboardButton[][] InlineKeyboard { get; set; }
    }
}
