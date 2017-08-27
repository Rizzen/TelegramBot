using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.API;
using TelegramBot.Bot.Types;


namespace TelegramBot.Bot.Updates
{
    internal class UpdateProvider
    {
        private readonly ApiClient _client;

        private int _updateOffset;

        public UpdateProvider(ApiClient apiClient)
        {
            _client = apiClient;
        }

        /// <summary>Getting Updates</summary>
        public async Task<ICollection<Update>> GetUpdates()
        {
            var response = await _client.SendRequestAsync<Responce>("getUpdates", new UpdatesRequest
            {
                Offset = _updateOffset
            });
            
            if (response.Success && response.Updates.Any())
            {              
                _updateOffset = response.Updates.Max(x => x.UpdateId) + 1;
                return response.Updates;
            }
            return new Update[] { };
        }
    }
}
