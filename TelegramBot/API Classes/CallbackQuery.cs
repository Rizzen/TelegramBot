namespace TelegramBot.API_Classes
{
    class CallbackQuery
    {
        //Unique identifier for this query
        public string Id { get; set; }
        //Sender
        public User From { get; set; }
        //Optional. Message with the callback button that originated the query. Note that message content and message date will not be available if the message is too old
        public Message Message { get; set; }
        //Optional. Identifier of the message sent via the bot in inline mode, that originated the query.
        public string InlineMessageId { get; set; }
        //Global identifier, uniquely corresponding to the chat to which the message with the callback button was sent. Useful for high scores in games.
        public string ChatInstance { get; set; }
        //Optional. Data associated with the callback button. Be aware that a bad client can send arbitrary data in this field.
        public string Data { get; set; }
        //Optional. Short name of a Game to be returned, serves as the unique identifier for the game
        public string GameShortName { get; set; }
    }
}
