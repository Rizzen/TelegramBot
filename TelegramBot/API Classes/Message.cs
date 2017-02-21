using Newtonsoft.Json;

namespace TelegramBot.API_Classes
{
    /// <summary>
    /// This object represents a message.
    /// </summary>
    internal class Message
    {

        /// <summary>
        /// Unique message identifier inside this chat
        /// </summary>
        [JsonProperty("message_id")]
        internal int MessageId { get; set; }

        /// <summary>
        /// Optional. Sender, can be empty for messages sent to channels
        /// </summary>
        [JsonProperty("from")]
        internal User From { get; set; }

        /// <summary>
        /// Date the message was sent in Unix time
        /// </summary>
        [JsonProperty("date")]
        internal int Date { get; set; }

        /// <summary>
        /// Conversation the message belongs to
        /// </summary>
        [JsonProperty("chat")]
        internal Chat Chat { get; set; }

        /// <summary>
        /// Optional. For forwarded messages, sender of the original message
        /// </summary>
        [JsonProperty("forwar_from")]
        internal User ForwardFrom { get; set; }

        /// <summary>
        /// Optional. For messages forwarded from a channel, information about the original channel
        /// </summary>
        [JsonProperty("forward_from_chat")]
        internal Chat ForwardFromChat { get; set; }

        /// <summary>
        /// Optional. For forwarded channel posts, identifier of the original message in the channel
        /// </summary>
        [JsonProperty("forward_date")]
        internal int ForwardDate { get; set; }

        //Optional. For forwarded messages, date the original message was sent in Unix time
        internal Message ReplyToMessage { get; set; }
        //Optional. Date the message was last edited in Unix time
        internal int EditDate { get; set; }
        //Optional.For text messages, the actual UTF-8 text of the message, 0-4096 characters.
        internal string Text { get; set; }
        //Optional. For text messages, special entities like usernames, URLs, bot commands, etc. that appear in the text
        internal MessageEntity[] Entitites { get; set; }
        //Optional. Message is an audio file, information about the file
        internal Audio Audio { get; set; }
        //Optional. Message is a general file, information about the file
        internal Document Document { get; set; }
        //Optional. Message is a game, information about the game.
        internal Game Game { get; set; }
        //Optional. Message is a photo, available sizes of the photo
        internal PhotoSize[] Photo { get; set; }
        //Optional. Message is a sticker, information about the sticker
        internal Sticker Sticker { get; set; }
        //Optional. Message is a video, information about the video
        internal Video Video { get; set; }
        //Optional. Message is a voice message, information about the file
        internal Voice Voice { get; set; }
        //Optional. Caption for the document, photo or video, 0-200 characters
        internal string Caption { get; set; }
        //Optional. Message is a shared contact, information about the contact
        internal Contact Contact { get; set; }
        //Optional. Message is a shared location, information about the location
        internal Location Location { get; set; }
        //Optional. Message is a venue, information about the venue
        internal Venue Venue { get; set; }
        //Optional. A new member was added to the group, information about them (this member may be the bot itself)
        internal User NewChatMember { get; set; }
        //Optional. A member was removed from the group, information about them (this member may be the bot itself)
        internal User LeftChatMember { get; set; }
        //Optional. A chat title was changed to this value
        internal string NewChatTitle { get; set; }
        //Optional. A chat photo was change to this value
        internal PhotoSize[] NewChatPhoto { get; set; }
        //Optional. Service message: the chat photo was deleted
        internal bool DeleteChatPhoto { get; set; }
        //Optional. Service message: the group has been created
        internal bool GroupChatCreated { get; set; }
        //Optional. Service message: the supergroup has been created. This field can‘t be received in a message coming through updates, because bot can’t be a member of a supergroup when it is created. It can only be found in reply_to_message if someone replies to a very first message in a directly created supergroup.
        internal bool SupergroupChatCreated { get; set; }
        //Optional. Service message: the channel has been created. This field can‘t be received in a message coming through updates, because bot can’t be a member of a channel when it is created. It can only be found in reply_to_message if someone replies to a very first message in a channel.
        internal bool ChannelChatCreated { get; set; }
        //Optional. The group has been migrated to a supergroup with the specified identifier. This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. But it smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier.
        internal int MigrateToChatId { get; set; }
        //Optional. The supergroup has been migrated from a group with the specified identifier. This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. But it smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier.
        internal int MigrateFromChatId { get; set; }
        //Optional. Specified message was pinned. Note that the Message object in this field will not contain further reply_to_message fields even if it is itself a reply.
        internal Message PinnedMessage { get; set; }

    }
}
