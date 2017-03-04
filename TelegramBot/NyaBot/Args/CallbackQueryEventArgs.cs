using System;
using TelegramBot.API_Classes;

namespace TelegramBot
{
    internal class CallbackQueryEventArgs : EventArgs
    {
        public CallbackQuery CallbackQuery { get; set; }
    }
}
