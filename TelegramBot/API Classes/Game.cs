namespace TelegramBot.API_Classes
{
    class Game
    {
        //Title of the game
        public string Title { get; set; }
        //Description of the game
        public string Description { get; set; }
        //Photo that will be displayed in the game message in chats.
        public PhotoSize[] Photo { get; set; }
        //Optional. Brief description of the game or high scores included in the game message. Can be automatically edited to include current high scores for the game when the bot calls setGameScore, or manually edited using editMessageText. 0-4096 characters.
        public string Text { get; set; }
        //Optional. Special entities that appear in text, such as usernames, URLs, bot commands, etc.
        public MessageEntity[] TextEntities { get; set; }
        //	Optional. Animation that will be displayed in the game message in chats. Upload via BotFather
        public Animation Animation { get; set; }
    }
}
