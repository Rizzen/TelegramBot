namespace TelegramBot.API_Classes
{
    internal class MessageEntity
    {
        //Type of the entity. Can be mention (@username), hashtag, bot_command, url, email, bold (bold text), italic (italic text), code (monowidth string), pre (monowidth block), text_link (for clickable text URLs), text_mention (for users without usernames)
        internal string Type { get; set; }
        //Offset in UTF-16 code units to the start of the entity
        internal int Offset { get; set; }
        //Length of the entity in UTF-16 code units
        internal int Length { get; set; }
        //Optional. For “text_link” only, url that will be opened after user taps on the text
        internal string Url { get; set; }
        //Optional. For “text_mention” only, the mentioned user
        internal User User { get; set; }
    }
}
