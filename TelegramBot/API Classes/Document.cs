namespace TelegramBot.API_Classes
{
    class Document
    {
        //Unique file identifier
        public string FileId { get; set; }
        //Optional. Document thumbnail as defined by sender
        public PhotoSize Thumb { get; set; }
        //Optional. Original filename as defined by sender
        public string FileName { get; set; }
        //Optional. MIME type of the file as defined by sender
        public string MimeType { get; set; }
        //	Optional. File size
        public int FileSize { get; set; }
    }
}
