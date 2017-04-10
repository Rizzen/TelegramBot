namespace TelegramBot.Bot.Replies
{
    public interface IReplyVisitor<in TArgs, out TResult>
    {
        TResult VisitText(TextReply reply, TArgs args);

        TResult VisitImage(ImageReply reply, TArgs args);

        TResult VisitButtons(ButtonsReply reply, TArgs args);
        TResult VisitDocument(DocumentReply reply, TArgs args);
        TResult VisitVideo(VideoReply reply, TArgs args);
    }
}