using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.API.Args
{
    internal class TelegramMessageEventArgs: EventArgs
    {
        public long ChatId { get; set; }
        public int MessageId { get; set; }
        public User From { get; set; }
        public Message Message { get; set; }
    }
}

