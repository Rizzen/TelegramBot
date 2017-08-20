using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.API;
using TelegramBot.Bot.Updates;

namespace TelegramBot.Bot
{
    class BotImpl: IBot
    {
        public bool IsRunning { get; private set; }
        private readonly ApiClient _api;
        private readonly UpdateProvider _updateProvider;
             
        public BotImpl(ApiClient api, UpdateProvider updateProvider)
        {
            _api = api;
            _updateProvider = updateProvider;
        }

        public async Task Start()
        {
            IsRunning = true;
            await UpdateRoutine();
            Console.ReadLine();
        }

        public void Stop()
        {
           // throw new NotImplementedException();
        }

        private async Task UpdateRoutine()
        {
            Console.WriteLine("Bot Started........");
            while (IsRunning)
            {
                await Task.Delay(1000);
                try
                {
                    var updates = await _updateProvider.GetUpdates();

                    foreach (var update in updates)
                    {
                        if (update.Message != null)
                        {
                            Console.WriteLine(update.Message.Text);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
