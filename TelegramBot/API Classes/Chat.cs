namespace TelegramBot.API_Classes
{
    class Chat
    {
        //Unique identifier for this chat. 
        //This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. 
        //But it smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier.
        public int Id { get; set; }
        //Type of chat, can be either “private”, “group”, “supergroup” or “channel”
        public string Type { get; set; }
        //Optional. Title, for supergroups, channels and group chats
        public string Title { get; set; }
        //	Optional. Username, for private chats, supergroups and channels if available
        public string Username { get; set; }
        //Optional. First name of the other party in a private chat
        public string FirstName { get; set; }
        //Optional. Last name of the other party in a private chat
        public string LastName { get; set; }
        //Optional. True if a group has ‘All Members Are Admins’ enabled.
        public bool AllMembersAreAdministrators { get; set; }


    }
}
