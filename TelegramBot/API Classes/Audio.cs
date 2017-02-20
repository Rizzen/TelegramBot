namespace TelegramBot.API_Classes
{
    class Audio
    {
        //Unique identifier for this file
        public string FileId { get; set; }
        //Duration of the audio in seconds as defined by sender
        public int Duration { get; set; }
        //Optional. Performer of the audio as defined by sender or by audio tags
        public string Performer { get; set; }
        //Optional. Title of the audio as defined by sender or by audio tags
        public string Title { get; set; }
        //Optional. MIME type of the file as defined by sender
        public string MimeType { get; set; }
        //Optional. File size
        public int FileSize { get; set; }
    }
}
