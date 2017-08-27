using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.API;
using TelegramBot.Bot.Updates;
using TelegramBot.Logging;

namespace TelegramBot.Bot
{
    internal class BotImpl: IBot
    {
        public bool IsRunning { get; private set; }
        private readonly ApiClient _api;
        private readonly UpdateProvider _updateProvider;

        private ILogger _logger;
             
        public BotImpl(ApiClient api, UpdateProvider updateProvider)
        {
            _api = api;
            _updateProvider = updateProvider;

            //это должно инжектиться
            _logger = new ConsoleLogger();
        }

        public async Task Start()
        {
            IsRunning = true;
            await UpdateRoutine();
            //Console.ReadLine();
        }

        public void Stop()
        {
            IsRunning = false;
            _logger.Log(LogLevel.Message, "!!!!!!!!!!Bot Stopped!!!!!!!!!!!");
        }

        private async Task UpdateRoutine()
        {
            _logger.Log(LogLevel.Message, "Bot Started........");

            while (IsRunning)
            {
                await Task.Delay(1000);
                try
                {
                    var updates = await _updateProvider.GetUpdates();

                    foreach (var update in updates)
                    {
                        if (update.Message != null)
                            _logger.Log(LogLevel.Message, update.Message.Text);
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
