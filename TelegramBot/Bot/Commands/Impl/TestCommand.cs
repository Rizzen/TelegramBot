using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;

namespace TelegramBot.Bot.Commands
{
    class TestCommand : Command
    {
        public override bool ShouldInvoke(TelegramMessageEventArgs input)
        {
            return input.Message?.Text?.EndsWith("ест") ?? false;
        }

        protected override Task<IEnumerable<IReply>> OnInvoke(TelegramMessageEventArgs input)
        {
            return Task.FromResult(GetReplies(input));
        }

        private IEnumerable<IReply> GetReplies(TelegramMessageEventArgs input)
        {
            yield return new ButtonsReply("Это кнопки", BotHelper.BuildKeyboard(BotHelper.BuildButtonsRow("ролл", "Вторая"), BotHelper.BuildButtonsRow("Третья")));
            //yield return new TextReply(input.Message.Text.Replace("ест", "хуест"));
            //yield return new ImageReply(File.ReadAllBytes(@"C:\Users\bashis\Desktop\photo_2017-02-08_14-48-48.jpg"));
        }
    }
}
