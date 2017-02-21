namespace TelegramBot.API_Classes
{
    internal class Voice
    {
        //Unique identifier for this file
        internal string FileId { get; set; }
        //Duration of the audio in seconds as defined by sender
        internal int Duration { get; set; }
        //Optional. MIME type of the file as defined by sender
        internal string MimeType { get; set; }
        //Optional. File size
        internal int FileSize { get; set; }
    }
}
