using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ninject;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;
using TelegramBot.Logging;
using TelegramBot.Util;

namespace TelegramBot.Bot.Commands
{
    class SosachCommand : Command
    {
        [Inject]
        public ILogger Logger { get; set; }

        private async Task<string> GetThreadsList(string boardName = "b")
        {
            string url = $"https://2ch.hk/{boardName}/catalog.json";
            var result = String.Empty;

            using (var client = new System.Net.WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    var jsonText = await client.DownloadStringTaskAsync(url);

                    var board = JsonConvert.DeserializeObject<TelegramBot.SosachBoard>(jsonText);

                    var builder = new StringBuilder();
                    builder.AppendLine("Доска: " + board.BoardName + Environment.NewLine);

                    for (int i = 0; i < 5; i++)
                    {
                        var thread = board.Threads[i];

                        builder.AppendLine("Тема: " + ((thread.Comment.Length < 300)
                                               ? thread.Comment
                                               : thread.Subject));
                        builder.AppendLine("Количество постов: " + board.Threads[i].PostsCount + Environment.NewLine);
                    }

                    result = builder.ToString();
                }
                catch (Exception e)
                {
                    Logger.Log(LogLevel.Error, e);
                }
            }

            return result;
        }

        public static bool CheckBoardName(string boardName)
        {
            foreach (var c in boardName)
            {
                if (!Char.IsLetter(c))
                {
                    return false;
                }
            }
            // хз, какая максимальная длина должна быть, потому что я не сосачер
            if (boardName.Length > 4 || boardName.Length < 1)
            {
                return false;
            }

            return true;
        }

        public override bool ShouldInvoke(TelegramMessageEventArgs input)
        {
            string prefix = "харкач";
            return MessageEquals(input, prefix) || Regex.IsMatch(input.Message.Text, prefix + @" +\/.", RegexOptions.IgnoreCase);
        }

        protected override async Task<IEnumerable<IReply>> OnInvoke(TelegramMessageEventArgs input)
        {
            string board = GetBoard(input.Message.Text);
            string output = await GetThreadsList(board);
            return new TextReply(output).Yield();
        }

        private string GetBoard(string message)
        {
            var match = Regex.Match(message, @"\/(.+)");
            if (match.Success && match.Groups.Count >=1)
            {
                var group = match.Groups[1];
                return group.Value;
            }

            return "b";
        }
    }

    internal class SosachBoard
    {
        [JsonProperty("BoardName")]
        public string BoardName { get; set; }

        [JsonProperty("threads")]
        public TelegramBot.SosachThread[] Threads { get; set; }
    }

    internal class SosachThread
    {
        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("posts_count")]
        public int PostsCount { get; set; }
    }
}
