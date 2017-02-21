namespace TelegramBot.API_Classes
{
    internal class Video
    {
        //Unique identifier for this file
        internal string FileId { get; set; }
        //Video width as defined by sender
        internal int Width { get; set; }
        //Video height as defined by sender
        internal int Height { get; set; }
        //Duration of the video in seconds as defined by sender
        internal int Duration { get; set; }
        //Optional. Video thumbnail
        internal PhotoSize Thumb { get; set; }
        //Optional. Mime type of a file as defined by sender
        internal string MimeType { get; set; }
        //Optional. File size
        internal int FileSize { get; set; }
    }
}
