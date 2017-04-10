using System;
using TelegramBot.API.Models;

namespace TelegramBot.Bot.Args
{
    public class TelegramMessageEventArgs : EventArgs
    {
        public long ChatId { get; set; }
        public int MessageId { get; set; }
        public User From { get; set; }
        public Message Message { get; set; }
    }
}
