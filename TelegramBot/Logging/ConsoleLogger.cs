using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Logging
{
    class ConsoleLogger : ILogger
    {
        private ConsoleColor _defaultColor;

        public void Log(LogLevel level, object item)
        {
            _defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = GetConsoleColor(level);
            string message = $"[{DateTime.Now:hh:mm:ss}] {level.GetDisplayString()}{Environment.NewLine}{item}{Environment.NewLine}";
            Console.Write(message);
            Console.ForegroundColor = _defaultColor;
        }

        private ConsoleColor GetConsoleColor(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Message:
                    return ConsoleColor.Gray;
                case LogLevel.Warning:
                    return ConsoleColor.DarkYellow;
                case LogLevel.Error:
                    return ConsoleColor.DarkRed;
                case LogLevel.Fatal:
                    return ConsoleColor.Red;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null); //should never happen
            }
        }
    }
}
