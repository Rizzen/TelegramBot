using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Logging
{
    class FileLogger : ILogger
    {
        private readonly string _directory;

        public FileLogger(string directory)
        {
            _directory = directory;
        }

        public void Log(LogLevel level, object item)
        {
            string message = $"[{DateTime.Now:hh:mm:ss}] {level.GetDisplayString()}{Environment.NewLine}{item}{Environment.NewLine}";
            string filename = GetFileName(level);
            File.AppendAllText(Path.Combine(_directory, filename + ".log"), message);

        }

        private string GetFileName(LogLevel level)
        {
            string mask = "{0}_" + DateTime.Today.ToString(@"yyyy-MM-dd");
            switch (level)
            {
                case LogLevel.Message:
                case LogLevel.Warning:
                    return string.Format(mask, "Log");
                case LogLevel.Error:
                case LogLevel.Fatal:
                    return string.Format(mask, "Errors");
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null); //should never happen
            }
        }
    }
}
