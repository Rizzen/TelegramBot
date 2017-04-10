using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ninject;
using TelegramBot.API;
using TelegramBot.API.Models;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;
using TelegramBot.Util;

namespace TelegramBot.Bot.Commands
{
    abstract class Command
    {
        [Inject]
        public IThrottleFilter ThrottleFilter { get; set; }

        public abstract bool ShouldInvoke(TelegramMessageEventArgs input);

        public async Task<IEnumerable<IReply>> Invoke(TelegramMessageEventArgs input)
        {
            if (ThrottleFilter != null && !ThrottleFilter.CanExecute())
            {
                TimeSpan remainingTime = ThrottleFilter.Frequency.Value - (DateTime.Now - ThrottleFilter.LastExecution);
                return new TextReply(GetOverThrottleText(remainingTime)).Yield();
            }

            IEnumerable<IReply> result = await OnInvoke(input);
            ThrottleFilter?.Executed();
            return result;
        }

        protected abstract Task<IEnumerable<IReply>> OnInvoke(TelegramMessageEventArgs input);

        protected static bool StringEquals(string x, string y)
        {
            return x!= null && y != null && string.Equals(x.Trim(), y.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        protected static bool MessageEquals(TelegramMessageEventArgs args, params string[] values)
        {
            return StringEqualsToOneOf(args?.Message?.Text, values);
        }

        private static bool StringEqualsToOneOf(string x, IEnumerable<string> ys)
        {
            return ys.Any(y => StringEquals(x, y));
        }

        protected static IEnumerable<IReply> Nothing => Enumerable.Empty<IReply>();

        protected static Task<IEnumerable<IReply>> FromResult(IReply reply)
        {
            return Task.FromResult(reply.Yield());
        }

        protected async Task<T> TryGet<T>(ApiClient client, string endpoint, object args = null) where T : class
        {
            var response = await client.SendRequestAsync<ApiResponse<T>>(endpoint, args);
            return response.Ok ? response.ResultObject : null;
        }

        protected void OneRequestPer(TimeSpan frequency)
        {
            if (ThrottleFilter != null)
            {
                ThrottleFilter.Frequency = frequency;
            }
        }

        protected virtual string GetOverThrottleText(TimeSpan remainingTime)
        {
            return "ѕрости, но это можно будет сделать только через " + remainingTime.ToHmsString();
        }
    }
}
