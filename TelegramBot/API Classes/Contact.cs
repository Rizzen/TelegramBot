namespace TelegramBot.API_Classes
{
    internal class Contact
    {
        //Contact's phone number
        internal string PhoneNumber { get; set; }
        //Contact's first name
        internal string FirstName { get; set; }
        //Optional. Contact's last name
        internal string LastName { get; set; }
        //Optional. Contact's user identifier in Telegram
        internal int UserId { get; set; }
    }
}
