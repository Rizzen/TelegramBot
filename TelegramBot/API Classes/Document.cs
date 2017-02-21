namespace TelegramBot.API_Classes
{
    internal class Document
    {
        //Unique file identifier
        internal string FileId { get; set; }
        //Optional. Document thumbnail as defined by sender
        internal PhotoSize Thumb { get; set; }
        //Optional. Original filename as defined by sender
        internal string FileName { get; set; }
        //Optional. MIME type of the file as defined by sender
        internal string MimeType { get; set; }
        //	Optional. File size
        internal int FileSize { get; set; }
    }
}
