namespace TelegramBot.API_Classes
{
    internal class PhotoSize
    {
        //Unique identifier for this file
        internal string FileId { get; set; }
        //Photo width
        internal int Width { get; set; }
        //Photo height
        internal int Height { get; set; }
        //Optional. File size
        internal int FileSize { get; set; }
    }
}
