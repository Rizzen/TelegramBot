using System.Collections.Generic;
using System.Threading.Tasks;
using TelegramBot.API.Models;

namespace TelegramBot.Bot.Updates
{
    public interface IUpdatesProvider
    {
        Task<ICollection<Update>> GetUpdates();
    }
}