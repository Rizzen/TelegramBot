using System;
using System.Threading.Tasks;
using TelegramBot.API;
using TelegramBot.API.Args;
using TelegramBot.Bot.Commands;
using TelegramBot.Bot.Replies;
using TelegramBot.Bot.Updates;
using TelegramBot.Logging;


namespace TelegramBot.Bot
{
    internal class BotImpl: IBot
    {
        public bool IsRunning { get; private set; }

        private readonly ApiClient _api;
        private readonly UpdateProvider _updateProvider;
        private readonly ICommandInvoker _invoker;
        private readonly IReplySender _replySender;

        private readonly ILogger _logger;
        private ApiClient api;
        private UpdateProvider updateProvider;

        public BotImpl(ApiClient api, UpdateProvider updateProvider, ICommandInvoker invoker, IReplySender replySender)
        {
            _api = api;
            _updateProvider = updateProvider;
            _invoker = invoker;
            _replySender = replySender;

            //это должно инжектиться
            _logger = new ConsoleLogger();
        }

        public async Task Start()
        {
            IsRunning = true;
            await UpdateRoutine();
        }

        public void Stop()
        {
            IsRunning = false;
            _logger.Log(LogLevel.Message, "Bot Stopped!");
        }

        private async Task UpdateRoutine()
        {
            _logger.Log(LogLevel.Message, "Bot Started..");

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
                    ProcessException(e);
                }
            }
        }

        private async Task ProcessMessage(Message message)
        {
            var args = new TelegramMessageEventArgs
            {
                ChatId = message.Chat.Id,
                MessageId = message.MessageId,
                From = message.From,
                Message = message
            };

            var results = await _invoker.Invoke(args);

            foreach (var result in results)
            {
                //сюда reply sender
            }
        }
        
        private void ProcessException(Exception ex)
        {
            IsRunning = false;
            _logger?.Log(LogLevel.Fatal, ex.Message);
        }
    }
}
