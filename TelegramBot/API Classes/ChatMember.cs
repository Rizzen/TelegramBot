namespace TelegramBot.API_Classes
{
    internal class ChatMember
    {
        //Information about the user
        internal User User { get; set; }
        //The member's status in the chat. Can be “creator”, “administrator”, “member”, “left” or “kicked”
        internal string Status { get; set; }
    }
}
