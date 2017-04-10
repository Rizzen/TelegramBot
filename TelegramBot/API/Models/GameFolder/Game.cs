using Newtonsoft.Json;

namespace TelegramBot.API.Models.GameFolder
{
    /// <summary>
    /// You can provide an animation for your game so that it looks stylish in chats (check out Lumberjack for an example). 
    /// This object represents an animation file to be displayed in the message containing a game.
    /// </summary>
    internal class Game
    {
        /// <summary>
        /// Title of the game
        /// </summary>
        [JsonProperty("title")]
        internal string Title { get; set; }

        /// <summary>
        /// Description of the game
        /// </summary>
        [JsonProperty("description")]
        internal string Description { get; set; }

        /// <summary>
        /// Photo that will be displayed in the game message in chats.
        /// </summary>
        [JsonProperty("photo")]
        internal PhotoSize[] Photo { get; set; }

        /// <summary>
        /// Optional. Brief description of the game or high scores included in the game message. 
        /// Can be automatically edited to include current high scores for the game when the bot calls setGameScore, or manually edited using editMessageText. 
        /// 0-4096 characters.
        /// </summary>
        [JsonProperty("text")]
        internal string Text { get; set; }

        /// <summary>
        /// Optional. Special entities that appear in text, such as usernames, URLs, bot commands, etc.
        /// </summary>
        [JsonProperty("text_entities")]
        internal MessageEntity[] TextEntities { get; set; }

        /// <summary>
        /// Optional. Animation that will be displayed in the game message in chats. Upload via BotFather
        /// </summary>
        [JsonProperty("animation")]
        internal Animation Animation { get; set; }
    }
}
