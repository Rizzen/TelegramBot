using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramBot.API;
using TelegramBot.API.Models;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;
using TelegramBot.Util;

namespace TelegramBot.Bot.Commands
{
    class MeCommand : Command 
    {
        private readonly ApiClient _client;

        public override bool ShouldInvoke(TelegramMessageEventArgs input)
        {
            return MessageEquals(input, "getme");
        }

        protected override async Task<IEnumerable<IReply>> OnInvoke(TelegramMessageEventArgs input)
        {
            var user = await TryGet<User>(_client, "getme");
            if (user?.Username == null) return Nothing;

            return new TextReply($"Привет, меня зовут {user.Username}").Yield();
        }


        public MeCommand(ApiClient client)
        {
            _client = client;
        }
    }
}
