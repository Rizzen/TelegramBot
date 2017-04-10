using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.API.Models;

namespace TelegramBot.Bot.Replies
{
    public class ButtonsReply : IReply
    {
        public string Title { get; }
        public ReplyKeyboardMarkup Markup { get; set; }

        public ButtonsReply(string title, KeyboardButton[][] buttons)
        {
            Title = title;
            Markup = new ReplyKeyboardMarkup()
            {
                Keyboard = buttons
            };
        }

        public TResult AcceptVisitor<TArgs, TResult>(IReplyVisitor<TArgs, TResult> visitor, TArgs args)
        {
            return visitor.VisitButtons(this, args);
        }
    }
}
