namespace TelegramBot.API_Classes
{
    internal class UserProfilePhotos
    {
        //Total number of profile pictures the target user has
        internal int TotalCount { get; set; }
        //Requested profile pictures (in up to 4 sizes each)
        internal PhotoSize[][] Photos { get; set; }

    }
}
