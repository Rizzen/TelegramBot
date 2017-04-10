using System;
using TelegramBot.API.Models;

namespace TelegramBot.Bot.Args
{
    internal class CallbackQueryEventArgs : EventArgs
    {
        public CallbackQuery CallbackQuery { get; set; }
    }
}
