namespace TelegramBot.API_Classes
{
    class Contact
    {
        //Contact's phone number
        public string PhoneNumber { get; set; }
        //Contact's first name
        public string FirstName { get; set; }
        //Optional. Contact's last name
        public string LastName { get; set; }
        //Optional. Contact's user identifier in Telegram
        public int UserId { get; set; }
    }
}
