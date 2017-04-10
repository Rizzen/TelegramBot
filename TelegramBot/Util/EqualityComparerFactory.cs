using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Util
{
    internal static class EqualityComparerFactory<T>
    {
        public static IEqualityComparer<T> Create(Func<T, T, bool> equals)
        {
            return new Comparer(equals);
        }

        private class Comparer : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> _equals;

            public Comparer(Func<T, T, bool> equals)
            {
                _equals = @equals;
            }

            public bool Equals(T x, T y)
            {
                return _equals(x, y);
            }

            public int GetHashCode(T obj)
            {
                return 42;
            }
        }
    }

    
}
