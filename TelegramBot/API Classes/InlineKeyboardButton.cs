namespace TelegramBot.API_Classes
{
    class InlineKeyboardButton
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public string CallbackData { get; set; }
        public string SwitchInlineQuery { get; set; }
        public string SwitchInlineQueryCurrentChat { get; set; }
        public CallbackGame CallbackGame { get; set; }
    }
}
