using System;
using TelegramBot.API_Classes;

namespace TelegramBot.NyaBot.Args
{
    internal class TelegramMessageEventArgs : EventArgs
    {
        public long ChatId { get; set; }
        public int MessageId { get; set; }
        public User From { get; set; }
        public Message Message { get; set; }
    }
}
