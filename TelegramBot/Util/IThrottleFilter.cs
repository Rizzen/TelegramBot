using System;

namespace TelegramBot.Util
{
    public interface IThrottleFilter
    {
        bool CanExecute();
        void Executed();
        TimeSpan? Frequency { get; set; }

        DateTime LastExecution { get; }
    }
}