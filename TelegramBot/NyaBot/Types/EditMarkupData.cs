﻿using Newtonsoft.Json;
using TelegramBot.API_Classes;

namespace TelegramBot
{
    internal class EditMarkupData
    {
        [JsonProperty("chat_id")]
        public string ChatId { get; set; }

        [JsonProperty("message_id")]
        public int MessageId { get; set; }

        [JsonProperty("inline_message_id")]
        public string InlineMessageId { get; set; }

        [JsonProperty("reply_markup")]
        public InlineKeyboardMarkup ReplyMarkup { get; set; }
    }
}
