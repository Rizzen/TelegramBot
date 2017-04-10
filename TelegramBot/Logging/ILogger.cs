namespace TelegramBot.Logging
{
    public interface ILogger
    {
        void Log(LogLevel level, object item);
    }
}