using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.API_Classes
{
    class Voice
    {
        //Unique identifier for this file
        public string FileId { get; set; }
        //Duration of the audio in seconds as defined by sender
        public int Duration { get; set; }
        //Optional. MIME type of the file as defined by sender
        public string MimeType { get; set; }
        //Optional. File size
        public int FileSize { get; set; }
    }
}
