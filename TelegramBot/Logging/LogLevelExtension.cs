using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Logging
{
    internal static class LogLevelExtension
    {
        public static string GetDisplayString(this LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Message:
                    return "Message";
                case LogLevel.Error:
                    return "Error";
                case LogLevel.Fatal:
                    return "Fatal";
                case LogLevel.Warning:
                    return "Warning";
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }
    }
}
