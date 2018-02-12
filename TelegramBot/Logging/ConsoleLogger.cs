using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Logging
{
    internal class ConsoleLogger: ILogger
    {
        private ConsoleColor _defaultColor;

        public void Log(LogLevel logLevel, object item)
        {
            _defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = GetConsoleColor(logLevel);
            var message = $"[{DateTime.Now:hh:mm:ss}] {logLevel.GetDisplayString()}{Environment.NewLine}{item}{Environment.NewLine}";
            Console.WriteLine(message);
            Console.ForegroundColor = _defaultColor;
        }

        private ConsoleColor GetConsoleColor(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Message:
                    return ConsoleColor.Gray;
                case LogLevel.Warning:
                    return ConsoleColor.Yellow;
                case LogLevel.Error:
                    return ConsoleColor.Red;
                case LogLevel.Fatal:
                    return ConsoleColor.DarkRed;
                default: 
                    throw new ArgumentOutOfRangeException(nameof(logLevel),logLevel,null); 
            }
        }
    }
}
