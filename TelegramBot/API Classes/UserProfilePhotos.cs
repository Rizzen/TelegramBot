namespace TelegramBot.API_Classes
{
    class UserProfilePhotos
    {
        //Total number of profile pictures the target user has
        public int TotalCount { get; set; }
        //Requested profile pictures (in up to 4 sizes each)
        public PhotoSize[][] Photos { get; set; }

    }
}
