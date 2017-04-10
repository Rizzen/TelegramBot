using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Logging
{
    public static class LogExtensions
    {
        public static void Log(this ILogger logger, Exception ex)
        {
            logger?.Log(LogLevel.Error, ex);
        }
    }
}
