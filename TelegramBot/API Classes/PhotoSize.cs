namespace TelegramBot.API_Classes
{
    class PhotoSize
    {
        //Unique identifier for this file
        public string FileId { get; set; }
        //Photo width
        public int Width { get; set; }
        //Photo height
        public int Height { get; set; }
        //Optional. File size
        public int FileSize { get; set; }
    }
}
