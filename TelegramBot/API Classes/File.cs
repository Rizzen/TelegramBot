namespace TelegramBot.API_Classes
{
    class File
    {
        /*
         * This object represents a file ready to be downloaded. 
         * The file can be downloaded via the link https://api.telegram.org/file/bot<token>/<file_path>. 
         * It is guaranteed that the link will be valid for at least 1 hour. 
         * When the link expires, a new one can be requested by calling getFile.
         */
        //Unique identifier for this file
        public string FileId { get; set; }
        //Optional. File size, if known
        public int FileSize { get; set; }
        //Optional. File path. Use https://api.telegram.org/file/bot<token>/<file_path> to get the file.
        public string FilePath { get; set; }

    }
}
