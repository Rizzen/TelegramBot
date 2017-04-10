using Newtonsoft.Json;
using TelegramBot.API.Models.GameFolder;

namespace TelegramBot.API.Models
{
    /// <summary>
    /// This object represents a message.
    /// </summary>
    public class Message
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

        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent in Unix time
        /// </summary>
        [JsonProperty("reply_to_message")]
        internal Message ReplyToMessage { get; set; }

        /// <summary>
        /// Optional. Date the message was last edited in Unix time
        /// </summary>
        [JsonProperty("edit_date")]
        internal int EditDate { get; set; }

        /// <summary>
        /// Optional.For text messages, the actual UTF-8 text of the message, 0-4096 characters.
        /// </summary>
        [JsonProperty("text")]
        internal string Text { get; set; }

        /// <summary>
        /// Optional. For text messages, special entities like usernames, URLs, bot commands, etc. that appear in the text
        /// </summary>
        [JsonProperty("entities")]
        internal MessageEntity[] Entitites { get; set; }

        /// <summary>
        /// Optional. Message is an audio file, information about the file
        /// </summary>
        [JsonProperty("audio")]
        internal Audio Audio { get; set; }

        /// <summary>
        /// Optional. Message is a general file, information about the file
        /// </summary>
        [JsonProperty("document")]
        internal Document Document { get; set; }

        /// <summary>
        /// Optional. Message is a game, information about the game.
        /// </summary>
        [JsonProperty("game")]
        internal Game Game { get; set; }

        /// <summary>
        /// Optional. Message is a photo, available sizes of the photo
        /// </summary>
        [JsonProperty("photo")]
        internal PhotoSize[] Photo { get; set; }

        /// <summary>
        /// Optional. Message is a sticker, information about the sticker
        /// </summary>
        [JsonProperty("sticker")]
        internal Sticker Sticker { get; set; }

        /// <summary>
        /// Optional. Message is a video, information about the video
        /// </summary>
        [JsonProperty("video")]
        internal Video Video { get; set; }

        /// <summary>
        /// Optional. Message is a voice message, information about the file
        /// </summary>
        [JsonProperty("voice")]
        internal Voice Voice { get; set; }

        /// <summary>
        /// Optional. Caption for the document, photo or video, 0-200 characters
        /// </summary>
        [JsonProperty("caption")]
        internal string Caption { get; set; }

        /// <summary>
        /// Optional. Message is a shared contact, information about the contact
        /// </summary>
        [JsonProperty("contact")]
        internal Contact Contact { get; set; }

        /// <summary>
        /// Optional. Message is a shared location, information about the location
        /// </summary>
        [JsonProperty("location")]
        internal Location Location { get; set; }

        /// <summary>
        /// Optional. Message is a venue, information about the venue
        /// </summary>
        [JsonProperty("venue")]
        internal Venue Venue { get; set; }

        /// <summary>
        /// Optional. A new member was added to the group, information about them (this member may be the bot itself)
        /// </summary>
        [JsonProperty("new_chat_member")]
        internal User NewChatMember { get; set; }

        /// <summary>
        /// Optional. A member was removed from the group, information about them (this member may be the bot itself)
        /// </summary>
        [JsonProperty("left_chat_member")]
        internal User LeftChatMember { get; set; }

        /// <summary>
        /// Optional. A chat title was changed to this value
        /// </summary>
        [JsonProperty("new_chat_title")]
        internal string NewChatTitle { get; set; }

        /// <summary>
        /// Optional. A chat photo was change to this value
        /// </summary>
        [JsonProperty("new_chat_photo")]
        internal PhotoSize[] NewChatPhoto { get; set; }

        /// <summary>
        /// Optional. Service message: the chat photo was deleted
        /// </summary>
        [JsonProperty("delete_chat_photo")]
        internal bool DeleteChatPhoto { get; set; }

        /// <summary>
        /// Optional. Service message: the group has been created
        /// </summary>
        [JsonProperty("group_chat_created")]
        internal bool GroupChatCreated { get; set; }

        /// <summary>
        /// Optional. Service message: the supergroup has been created. 
        /// This field can‘t be received in a message coming through updates, because bot can’t be a member of a supergroup when it is created. 
        /// It can only be found in reply_to_message if someone replies to a very first message in a directly created supergroup.
        /// </summary>
        [JsonProperty("supergroup_chat_created")]
        internal bool SupergroupChatCreated { get; set; }

        /// <summary>
        /// Optional. Service message: the channel has been created. 
        /// This field can‘t be received in a message coming through updates, because bot can’t be a member of a channel when it is created. 
        /// It can only be found in reply_to_message if someone replies to a very first message in a channel.
        /// </summary>
        [JsonProperty("channel_chat_created")]
        internal bool ChannelChatCreated { get; set; }

        /// <summary>
        /// Optional. The group has been migrated to a supergroup with the specified identifier. 
        /// This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. 
        /// But it smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier.
        /// </summary>
        [JsonProperty("migrate_to_chat_id")]
		internal long MigrateToChatId { get; set; }

        /// <summary>
        /// Optional. The supergroup has been migrated from a group with the specified identifier. 
        /// This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. But it smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier.
        /// </summary>
        [JsonProperty("migrate_from_chat_id")]
        internal long MigrateFromChatId { get; set; }

        /// <summary>
        /// Optional. Specified message was pinned. 
        /// Note that the Message object in this field will not contain further reply_to_message fields even if it is itself a reply.
        /// </summary>
        [JsonProperty("pinned_message")]
        internal Message PinnedMessage { get; set; }

    }
}
