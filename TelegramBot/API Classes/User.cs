namespace TelegramBot.API_Classes
{
    internal class User
    {
        //Unique identifier for this user or bot
        internal int Id { get; set; }
        //User‘s or bot’s first name
        internal string FirstName { get; set; }
        //Optional. User‘s or bot’s last name
        internal string LastName { get; set; }
        //Optional. User‘s or bot’s username
        internal string Username { get; set; }

    }
}
