namespace TelegramBot.Bot.Replies
{
    public class TextReply : IReply
    {
        public string Text { get; set; }

        public TextReply(string text)
        {
            Text = text;
        }

        public TResult AcceptVisitor<TArgs, TResult>(IReplyVisitor<TArgs, TResult> visitor, TArgs args)
        {
            return visitor.VisitText(this, args);
        }
    }
}
