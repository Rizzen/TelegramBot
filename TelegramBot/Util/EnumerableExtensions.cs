using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Util
{
    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }

        private static readonly Random _random = new Random();

        public static T PickRandom<T>(this ICollection<T> collection)
        {
            int index = _random.Next(collection.Count);
            return collection.ElementAt(index);
        }
    }
}
