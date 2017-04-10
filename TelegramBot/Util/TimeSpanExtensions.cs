using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Util
{
    internal static class TimeSpanExtensions
    {
        public static string ToHmsString(this TimeSpan timespan)
        {
            return timespan.ToString(@"hh\:mm\:ss");
        }
    }
}
