namespace TelegramBot.API_Classes
{
    class Sticker
    {
        //Unique identifier for this file
        public string FileId { get; set; }
        //Sticker width
        public int Width { get; set; }
        //Sticker height
        public int Height { get; set; }
        //Optional. Sticker thumbnail in .webp or .jpg format
        public PhotoSize Thumb { get; set; }
        //Optional. Emoji associated with the sticker
        public string Emoji { get; set; }
        //Optional. File size
        public int FileSize { get; set; }
    }
}
