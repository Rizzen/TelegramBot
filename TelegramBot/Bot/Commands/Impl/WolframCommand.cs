using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;
using WolframAlphaNET;
using WolframAlphaNET.Objects;

namespace TelegramBot.Bot.Commands
{
    class WolframCommand : Command
    {
        private static string ApiToken => ConfigurationManager.AppSettings["wolframAlphaToken"];

        public override bool ShouldInvoke(TelegramMessageEventArgs input)
        {
            OneRequestPer(TimeSpan.FromSeconds(30));
            return input?.Message?.Text.StartsWith("!") ?? false;
        }

        protected override Task<IEnumerable<IReply>> OnInvoke(TelegramMessageEventArgs input)
        {
            string expression = input.Message.Text.Substring(1);

            WolframAlpha wolfram = new WolframAlpha(ApiToken);
            
            QueryResult results = wolfram.Query(expression);
            if (results == null) return Task.FromResult(Nothing);

            var sb = new StringBuilder();
            
            foreach (var pod in results.Pods)
            {
                sb.AppendLine(pod.Title);

                if (pod.SubPods == null) continue;

                foreach (var subPod in pod.SubPods)
                {
                    sb.AppendLine(subPod.Title);
                    sb.AppendLine(subPod.Plaintext);
                }
            }

            return FromResult(new TextReply(sb.ToString()));
        }
    }
}
