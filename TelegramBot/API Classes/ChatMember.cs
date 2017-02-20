namespace TelegramBot.API_Classes
{
    class ChatMember
    {
        //Information about the user
        public User User { get; set; }
        //The member's status in the chat. Can be “creator”, “administrator”, “member”, “left” or “kicked”
        public string Status { get; set; }
    }
}
