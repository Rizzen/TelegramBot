namespace TelegramBot.API_Classes
{
    class Video
    {
        //Unique identifier for this file
        public string FileId { get; set; }
        //Video width as defined by sender
        public int Width { get; set; }
        //Video height as defined by sender
        public int Height { get; set; }
        //Duration of the video in seconds as defined by sender
        public int Duration { get; set; }
        //Optional. Video thumbnail
        public PhotoSize Thumb { get; set; }
        //Optional. Mime type of a file as defined by sender
        public string MimeType { get; set; }
        //Optional. File size
        public int FileSize { get; set; }
    }
}
