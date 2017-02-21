namespace TelegramBot.API_Classes
{
    internal class KeyboardButton
    {
        //Text of the button. If none of the optional fields are used, it will be sent to the bot as a message when the button is pressed
        internal string Text { get; set; }
        //Optional. If True, the user's phone number will be sent as a contact when the button is pressed. Available in private chats only
        internal bool RequestContact { get; set; }
        //Optional. If True, the user's current location will be sent when the button is pressed. Available in private chats only
        internal bool RequestLocation { get; set; }

    }
}
