namespace TelegramBot.API_Classes
{
    internal class Chat
    {
        //Unique identifier for this chat. 
        //This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. 
        //But it smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier.
        internal int Id { get; set; }
        //Type of chat, can be either “private”, “group”, “supergroup” or “channel”
        internal string Type { get; set; }
        //Optional. Title, for supergroups, channels and group chats
        internal string Title { get; set; }
        //	Optional. Username, for private chats, supergroups and channels if available
        internal string Username { get; set; }
        //Optional. First name of the other party in a private chat
        internal string FirstName { get; set; }
        //Optional. Last name of the other party in a private chat
        internal string LastName { get; set; }
        //Optional. True if a group has ‘All Members Are Admins’ enabled.
        internal bool AllMembersAreAdministrators { get; set; }


    }
}
