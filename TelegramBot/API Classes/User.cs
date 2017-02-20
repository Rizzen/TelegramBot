namespace TelegramBot.API_Classes
{
    public class User
    {
        //Unique identifier for this user or bot
        public int Id { get; set; }
        //User‘s or bot’s first name
        public string FirstName { get; set; }
        //Optional. User‘s or bot’s last name
        public string LastName { get; set; }
        //Optional. User‘s or bot’s username
        public string Username { get; set; }

    }
}
