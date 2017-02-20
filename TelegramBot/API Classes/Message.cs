namespace TelegramBot.API_Classes
{
    class Message
    {
        //Unique message identifier inside this chat
        public int MessageId { get; set; }
        //Optional. Sender, can be empty for messages sent to channels
        public User From { get; set; }
        //Date the message was sent in Unix time
        public int Date { get; set; }
        //Conversation the message belongs to
        public Chat Chat { get; set; }
        //Optional. For forwarded messages, sender of the original message
        public User ForwardFrom { get; set; }
        //Optional. For messages forwarded from a channel, information about the original channel
        public Chat ForwardFromChat { get; set; }
        //Optional. For forwarded channel posts, identifier of the original message in the channel
        public int ForwardDate { get; set; }
        //Optional. For forwarded messages, date the original message was sent in Unix time
        public Message ReplyToMessage { get; set; }
        //Optional. Date the message was last edited in Unix time
        public int EditDate { get; set; }
        //Optional.For text messages, the actual UTF-8 text of the message, 0-4096 characters.
        public string Text { get; set; }
        //Optional. For text messages, special entities like usernames, URLs, bot commands, etc. that appear in the text
        public MessageEntity[] Entitites { get; set; }
        //Optional. Message is an audio file, information about the file
        public Audio Audio { get; set; }
        //Optional. Message is a general file, information about the file
        public Document Document { get; set; }
        //Optional. Message is a game, information about the game.
        public Game Game { get; set; }
        //Optional. Message is a photo, available sizes of the photo
        public PhotoSize[] Photo { get; set; }
        //Optional. Message is a sticker, information about the sticker
        public Sticker Sticker { get; set; }
        //Optional. Message is a video, information about the video
        public Video Video { get; set; }
        //Optional. Message is a voice message, information about the file
        public Voice Voice { get; set; }
        //Optional. Caption for the document, photo or video, 0-200 characters
        public string Caption { get; set; }
        //Optional. Message is a shared contact, information about the contact
        public Contact Contact { get; set; }
        //Optional. Message is a shared location, information about the location
        public Location Location { get; set; }
        //Optional. Message is a venue, information about the venue
        public Venue Venue { get; set; }
        //Optional. A new member was added to the group, information about them (this member may be the bot itself)
        public User NewChatMember { get; set; }
        //Optional. A member was removed from the group, information about them (this member may be the bot itself)
        public User LeftChatMember { get; set; }
        //Optional. A chat title was changed to this value
        public string NewChatTitle { get; set; }
        //Optional. A chat photo was change to this value
        public PhotoSize[] NewChatPhoto { get; set; }
        //Optional. Service message: the chat photo was deleted
        public bool DeleteChatPhoto { get; set; }
        //Optional. Service message: the group has been created
        public bool GroupChatCreated { get; set; }
        //Optional. Service message: the supergroup has been created. This field can‘t be received in a message coming through updates, because bot can’t be a member of a supergroup when it is created. It can only be found in reply_to_message if someone replies to a very first message in a directly created supergroup.
        public bool SupergroupChatCreated { get; set; }
        //Optional. Service message: the channel has been created. This field can‘t be received in a message coming through updates, because bot can’t be a member of a channel when it is created. It can only be found in reply_to_message if someone replies to a very first message in a channel.
        public bool ChannelChatCreated { get; set; }
        //Optional. The group has been migrated to a supergroup with the specified identifier. This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. But it smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier.
        public int MigrateToChatId { get; set; }
        //Optional. The supergroup has been migrated from a group with the specified identifier. This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. But it smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier.
        public int MigrateFromChatId { get; set; }
        //Optional. Specified message was pinned. Note that the Message object in this field will not contain further reply_to_message fields even if it is itself a reply.
        public Message PinnedMessage { get; set; }

    }
}
