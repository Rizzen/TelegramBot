namespace TelegramBot.API_Classes
{
    class Venue
    {
        //Venue location
        public Location Location { get; set; }
        //Name of the venue
        public string Title { get; set; }
        //Address of the venue
        public string Address { get; set; }
        //Optional. Foursquare identifier of the venue
        public string FoursquareId { get; set; }
    }
}
