using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBot.API;
using TelegramBot.API.Models;
using TelegramBot.Bot.Types;

namespace TelegramBot.Bot.Updates
{
    class UpdatesProvider : IUpdatesProvider
    {
        private readonly ApiClient _client;

        private int _updateOffset = 0;
        private List<int> _processedUpdates = new List<int>();

        public UpdatesProvider(ApiClient client)
        {
            _client = client;
        }

        public async Task<ICollection<Update>> GetUpdates()
        {
            var response = await _client.SendRequestAsync<Response>("getUpdates", new UpdatesRequest
            {
                Offset = _updateOffset
            });
            
            if (response.Success && response.Updates.Any())
            {
                _updateOffset = response.Updates.Max(t=>t.UpdateId) + 1;
                return response.Updates;
            }

            return new Update[] { };
        }
    }
}
