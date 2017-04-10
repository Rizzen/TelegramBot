using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.API.Models;

namespace TelegramBot.Util
{
    class RecordsTable
    {
        private readonly Dictionary<User, int> _data =
            new Dictionary<User, int>(EqualityComparerFactory<User>.Create((x, y) => x.Id == y.Id));

        public IReadOnlyDictionary<User, int> Data => _data;

        public int GetPoints(User user)
        {
            return _data.TryGetValue(user, out int score) ? score : 0;
        }

        public void AddPoints(User user, int points)
        {
            if (!_data.ContainsKey(user))
            {
                _data.Add(user, points);
                return;
            }

            _data[user] += points;
        }
    }
}
