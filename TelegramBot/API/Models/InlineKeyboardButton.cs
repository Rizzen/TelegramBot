using Newtonsoft.Json;
using TelegramBot.API.Models.GameFolder;

namespace TelegramBot.API.Models
{
    /// <summary>
    /// This object represents one button of an inline keyboard. You must use exactly one of the optional fields.
    /// </summary>
    internal class InlineKeyboardButton
    {
        /// <summary>
        /// Label text on the button
        /// </summary>
        [JsonProperty("text")]
        internal string Text { get; set; }

        /// <summary>
        /// Optional. HTTP url to be opened when button is pressed
        /// </summary>
        [JsonProperty("url")]
        internal string Url { get; set; }

        /// <summary>
        /// Optional. Data to be sent in a callback query to the bot when button is pressed, 1-64 bytes
        /// </summary>
        [JsonProperty("callback_data")]
        internal string CallbackData { get; set; }

        /// <summary>
        /// Optional. If set, pressing the button will prompt the user to select one of their chats, open that chat and insert the bot‘s username and the specified inline query in the input field. 
        /// Can be empty, in which case just the bot’s username will be inserted.
        /// </summary>
        [JsonProperty("switch_inline_query")]
        internal string SwitchInlineQuery { get; set; }

        /// <summary>
        /// Optional. If set, pressing the button will prompt the user to select one of their chats, open that chat and insert the bot‘s username and the specified inline query in the input field. 
        /// Can be empty, in which case just the bot’s username will be inserted.
        /// </summary>
        [JsonProperty("switch_inline_query_current_chat")]
        internal string SwitchInlineQueryCurrentChat { get; set; }

        /// <summary>
        /// Optional. If set, pressing the button will insert the bot‘s username and the specified inline query in the current chat's input field.
        /// Can be empty, in which case only the bot’s username will be inserted.
        /// </summary>
        [JsonProperty("callback_game")]
        internal CallbackGame CallbackGame { get; set; }
    }
}
