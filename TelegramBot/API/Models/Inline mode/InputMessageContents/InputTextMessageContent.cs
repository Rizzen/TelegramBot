using Newtonsoft.Json;

namespace TelegramBot.API.Models.Inline_mode.InputMessageContents
{
    internal class InputTextMessageContent: InputMessageContent
    {
        //Represents the content of a text message to be sent as the result of an inline query.
        [JsonProperty("message_text")]
        internal string MessageText { get; set; }

        //Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic, fixed-width text or inline URLs in your bot's message.
        [JsonProperty("parse_mode")]
        internal string ParseMode { get; set; }

        //Optional. Disables link previews for links in the sent message
        [JsonProperty("disable_web_page_preview")]
        internal bool DisableWebPagePreview { get; set; }
    }
}
