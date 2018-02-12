using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TelegramBot.API.Types
{
    /// <summary>
    /// Represents simple message to send
    /// </summary>
    internal class MessageToSend
    {
        /// <summary>
        /// (Required) Unique identifier for the target chat or username of the target channel
        /// (in the format @channelusername)
        /// </summary>
        [JsonProperty("chat_id")]
        internal string ChatId { get; set; }

        /// <summary>(Required) Text of the message to be sent</summary>
        [JsonProperty("text")]
        internal string Text { get; set; }

        /// <summary>
        /// Send Markdown or HTML, if you want Telegram apps to show bold, italic,
        /// fixed-width text or inline URLs in your bot's message.
        ///  </summary>
        [JsonProperty("parse_mode")]
        internal string ParseMode { get; set; }

        /// <summary>Disables link previews for links in this message</summary>
        [JsonProperty("disable_web_page_preview")]
        internal bool DisableWebPagePreview { get; set; }

        /// <summary>
        /// Sends the message silently. Users will receive a notification with no sound
        /// </summary>
        [JsonProperty("disable_notification")]
        internal bool DisableNotification { get; set; }

        /// <summary>
        /// If the message is a reply, ID of the original message
        /// </summary>
        [JsonProperty("reply_to_message_id")]
        internal string ReplyToMessageId { get; set; }


       
    }
}
