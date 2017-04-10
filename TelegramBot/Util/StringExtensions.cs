using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Util
{
    internal static class StringExtensions
    {
        public static string StringJoin(this IEnumerable<string> items, string separator)
        {
            return string.Join(separator, items);
        }
    }
}
