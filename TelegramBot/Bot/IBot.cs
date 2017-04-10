using System.Threading.Tasks;

namespace TelegramBot.Bot
{
    public interface IBot
    {
        bool IsRunning { get; }

        Task Start();
        void Stop();
    }
}