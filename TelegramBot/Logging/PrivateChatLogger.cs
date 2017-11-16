using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Logging
{
    public class PrivateChatLogger: ILogger
    {
        private IEnumerable<string> _userNames;

        public PrivateChatLogger(IEnumerable<string> userNames)
        {
            _userNames = userNames;
        }

        public void Log(LogLevel logLevel, object item)
        {
            foreach (var userName in _userNames)
            {
                
            }
        }
    }
}
