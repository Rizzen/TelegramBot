using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Logging
{
    /// <summary> Providing log </summary>
    internal interface ILogger
    {
        void Log(LogLevel logLevel, object item);
    }
}
