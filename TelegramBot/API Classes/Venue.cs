namespace TelegramBot.API_Classes
{
    internal class Venue
    {
        //Venue location
        internal Location Location { get; set; }
        //Name of the venue
        internal string Title { get; set; }
        //Address of the venue
        internal string Address { get; set; }
        //Optional. Foursquare identifier of the venue
        internal string FoursquareId { get; set; }
    }
}
