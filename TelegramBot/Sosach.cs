using System;
using System.Text;
using Newtonsoft.Json;

namespace TelegramBot
{
    public class Sosach
    {
        public string GetThreadsList(string boardName = "b")
        {
            string url = $"https://2ch.hk/{boardName}/catalog.json";
            var result = String.Empty;

            using (var client = new System.Net.WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    var jsonText = client.DownloadString(url);

                    var board = JsonConvert.DeserializeObject<SosachBoard>(jsonText);

                    var builder = new StringBuilder();
                    builder.AppendLine("Доска: " + board.BoardName + Environment.NewLine);

                    for (int i = 0; i < 5; i++)
                    {
                        var thread = board.Threads[i];

                        builder.AppendLine("Тема: " + ((thread.Comment.Length < 300) ? thread.Comment : thread.Subject));
                        builder.AppendLine("Количество постов: " + board.Threads[i].PostsCount + Environment.NewLine);
                    }

                    result = builder.ToString();
                }
                catch (Exception e)
                {
                    Logger.LogError(e);
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
    }

    internal class SosachBoard
    {
        [JsonProperty("BoardName")]
        public string BoardName { get; set; }

        [JsonProperty("threads")]
        public SosachThread[] Threads { get; set; }
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
