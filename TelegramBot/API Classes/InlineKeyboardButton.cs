using TelegramBot.API_Classes.GameFolder;

namespace TelegramBot.API_Classes
{
    internal class InlineKeyboardButton
    {
        internal string Text { get; set; }
        internal string Url { get; set; }
        internal string CallbackData { get; set; }
        internal string SwitchInlineQuery { get; set; }
        internal string SwitchInlineQueryCurrentChat { get; set; }
        internal CallbackGame CallbackGame { get; set; }
    }
}
