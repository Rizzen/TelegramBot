using Newtonsoft.Json;
using TelegramBot.API.Models.Inline_mode;

namespace TelegramBot.API.Models
{
    /// <summary>
    /// This object represents an incoming update.
    /// At most one of the optional parameters can be present in any given update
    /// </summary>
    public class Update
    {
        /// <summary>
        /// The update‘s unique identifier. Update identifiers start from a certain positive number and increase sequentially. 
        /// This ID becomes especially handy if you’re using Webhooks, since it allows you to ignore repeated updates or to restore the correct update sequence, should they get out of order.
        /// </summary>
        /// , Required = Required.Always
        [JsonProperty("update_id")]
        internal int UpdateId { get; set; }

        /// <summary>
        /// New incoming message of any kind — text, photo, sticker, etc.
        /// </summary>
        /// 
        [JsonProperty("message")]
        internal Message Message { get; set; }

        /// <summary>
        /// New version of a message that is known to the bot and was edited
        /// </summary>
        [JsonProperty("edited_message")]
        internal Message EditedMessage { get; set; }

        /// <summary>
        /// New incoming channel post of any kind — text, photo, sticker, etc.
        /// </summary>
        [JsonProperty("channel_post")]
        internal Message ChannelPost { get; set; }

        /// <summary>
        /// New version of a channel post that is known to the bot and was edited
        /// </summary>
        [JsonProperty("edited_channel_post")]
        internal Message EditedChannelPost { get; set; }

        /// <summary>
        /// New incoming inline query
        /// </summary>
        [JsonProperty("inline_query")]
        internal InlineQuery InlineQuery { get; set; }

        /// <summary>
        /// The result of an inline query that was chosen by a user and sent to their chat partner
        /// </summary>
        [JsonProperty("chosen_inline_result")]
        internal ChosenInlineResult ChosenInlineResult { get; set; }

        /// <summary>
        /// New incoming callback query
        /// </summary>
        [JsonProperty("callback_query")]
        internal CallbackQuery CallbackQuery { get; set; }
    }
}
