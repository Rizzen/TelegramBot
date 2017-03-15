using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TelegramBot.API_Classes;

using TelegramBot.NyaBot.Args;
using TelegramBot.NyaBot.Handlers;
using TelegramBot.NyaBot.Types;

namespace TelegramBot.NyaBot
{
    public class NyanBot
    {
        private bool isRun = false;
        private int updateOffset = 0;
        private BotApiClient api = null;

        internal NyanBot(string token)
        {
            api = new BotApiClient(token);
        }

        internal void Start()
        {
            isRun = true;
            UpdatesThread();
        }

        internal void Stop()
        {
            isRun = false;
        }

        internal bool IsRun => isRun;

        internal User GetMe()
        {
            var json = api.SendRequest("getMe");
            try
            {
                var result = JsonConvert.DeserializeObject<ApiResponse<User>>(json);
                if (result.Ok) return result.ResultObject;
                else return null;
            }
            catch (JsonException e)
            {
                Logger.LogError(e);
                return null;
            }
        }

        internal async Task<User> GetMeAsync()
        {
            var json = await api.SendRequestAsync("getMe");
            try
            {
                var result = JsonConvert.DeserializeObject<ApiResponse<User>>(json);
                if (result.Ok) return result.ResultObject;
                else return null;
            }
            catch (JsonException e)
            {
                Logger.LogError(e);
                return null;
            }
        }

        internal void SendMessage(string chatId, string text, bool disableWebPagePreview = false,
                                bool disableNotification = false, int replyToMessageId = 0, object replyMarkup = null)
        {
            var message = new MessageToSend
            {
                ChatId = chatId,
                Text = text,
                DisableWebPagePreview = disableWebPagePreview,
                DisableNotification = disableNotification,
                ReplayToMessageId = replyToMessageId,
                ReplyMarkup = replyMarkup
            };

            api.SendRequest("sendMessage", message);
        }

        internal async Task SendMessageAsync(string chatId, string text, bool disableWebPagePreview = false,
                                bool disableNotification = false, int replyToMessageId = 0, object replyMarkup = null)
        {
            var message = new MessageToSend
            {
                ChatId = chatId,
                Text = text,
                DisableWebPagePreview = disableWebPagePreview,
                DisableNotification = disableNotification,
                ReplayToMessageId = replyToMessageId,
                ReplyMarkup = replyMarkup
            };

            await api.SendRequestAsync("sendMessage", message);
        }

        internal void EditMessageText(string chatId, string text, int messageId = 0, string inlineMessageId = null,
                             bool disableWebPagePreview = false, object replyMarkup = null)
        {
            var edit = new EditMessageData
            {
                ChatId = chatId,
                Text = text,
                MessageId = messageId,
                InlineMessageId = inlineMessageId,
                DisableWebPagePreview = disableWebPagePreview,
                ReplyMarkup = replyMarkup
            };

            api.SendRequest("editMessageText", edit);
        }

        internal async Task EditMessageTextAsync(string chatId, string text, int messageId = 0, string inlineMessageId = null,
                             bool disableWebPagePreview = false, object replyMarkup = null)
        {
            var edit = new EditMessageData
            {
                ChatId = chatId,
                Text = text,
                MessageId = messageId,
                InlineMessageId = inlineMessageId,
                DisableWebPagePreview = disableWebPagePreview,
                ReplyMarkup = replyMarkup
            };

            await api.SendRequestAsync("editMessageText", edit);
        }

        internal void EditMessageReplyMarkup(string chatId = null, int messageId = 0, string inlineMessageId = null,
                                           InlineKeyboardMarkup replyMarkup = null)
        {
            var edit = new EditMarkupData
            {
                ChatId = chatId,
                MessageId = messageId,
                InlineMessageId = inlineMessageId,
                ReplyMarkup = replyMarkup
            };

            api.SendRequest("editMessageReplyMarkup", edit);
        }

        internal async Task EditMessageReplyMarkupAsync(string chatId = null, int messageId = 0, string inlineMessageId = null,
                                           InlineKeyboardMarkup replyMarkup = null)
        {
            var edit = new EditMarkupData
            {
                ChatId = chatId,
                MessageId = messageId,
                InlineMessageId = inlineMessageId,
                ReplyMarkup = replyMarkup
            };

            await api.SendRequestAsync("editMessageReplyMarkup", edit);
        }

        internal void SendPhoto(string chatId, string photo, string caption = null, bool disableNotification = false,
                              int replyToMessageId = 0, object replyMarkup = null)
        {
            var photow = new PhotoToSend
            {
                ChatId = chatId,
                Photo = photo,
                Caption = caption,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                ReplyMarkup = replyMarkup
            };

            api.SendRequest("sendPhoto", photow);
		}

        internal async Task SendPhotoAsync(string chatId, string photo, string caption = null, bool disableNotification = false,
                      int replyToMessageId = 0, object replyMarkup = null)
        {
            var photow = new PhotoToSend
            {
                ChatId = chatId,
                Photo = photo,
                Caption = caption,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                ReplyMarkup = replyMarkup
            };

            await api.SendRequestAsync("sendPhoto", photow);
        }

        internal void SendSticker(string chatId, string sticker, bool disableNotification = false,
                                int replyToMessageId = 0, object replyMarkup = null)
        {
            var stickerw = new StickerToSend
            {
                ChatId = chatId,
                Sticker = sticker,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                ReplyMarkup = replyMarkup
            };

            api.SendRequest("sendSticker", stickerw);
        }

        internal async Task SendStickerAsync(string chatId, string sticker, bool disableNotification = false,
                        int replyToMessageId = 0, object replyMarkup = null)
        {
            var stickerw = new StickerToSend
            {
                ChatId = chatId,
                Sticker = sticker,
                DisableNotification = disableNotification,
                ReplyToMessageId = replyToMessageId,
                ReplyMarkup = replyMarkup
            };

            await api.SendRequestAsync("sendSticker", stickerw);
        }

        internal void SendChatAction(string chatId, ChatAction action)
        {
            string actionString = String.Empty;

            switch (action)
            {
                case ChatAction.Typing:
                    actionString = "typing";
                    break;
                case ChatAction.UploadPhoto:
                    actionString = "upload_photo";
                    break;
                case ChatAction.UploadAudio:
                    actionString = "upload_audio";
                    break;
                case ChatAction.UploadDocument:
                    actionString = "upload_document";
                    break;
                case ChatAction.UploadVideo:
                    actionString = "upload_video";
                    break;
                case ChatAction.FindLocation:
                    actionString = "find_location";
                    break;
            }

            var actionw = new ChatActionToSend
            {
                ChatId = chatId,
                Action = actionString
            };

            api.SendRequest("sendChatAction", actionw);
        }

        internal async Task SendChatActionAsync(string chatId, ChatAction action)
        {
            string actionString = String.Empty;

            switch (action)
            {
                case ChatAction.Typing:
                    actionString = "typing";
                    break;
                case ChatAction.UploadPhoto:
                    actionString = "upload_photo";
                    break;
                case ChatAction.UploadAudio:
                    actionString = "upload_audio";
                    break;
                case ChatAction.UploadDocument:
                    actionString = "upload_document";
                    break;
                case ChatAction.UploadVideo:
                    actionString = "upload_video";
                    break;
                case ChatAction.FindLocation:
                    actionString = "find_location";
                    break;
            }

            var actionw = new ChatActionToSend
            {
                ChatId = chatId,
                Action = actionString
            };

            await api.SendRequestAsync("sendChatAction", actionw);
        }

        // normal versions
        internal void SendMessage(long chatId, string text, bool disableWebPagePreview = false,
                                bool disableNotification = false, int replyToMessageId = 0, object replyMarkup = null) =>
        SendMessage(chatId.ToString(), text, disableWebPagePreview, disableNotification, replyToMessageId, replyMarkup);

        internal void EditMessageText(long chatId, string text, int messageId = 0, string inlineMessageId = null,
                             bool disableWebPagePreview = false, object replyMarkup = null) =>
        EditMessageText(chatId.ToString(), text, messageId, inlineMessageId, disableWebPagePreview, replyMarkup);

        internal void EditMessageReplyMarkup(long chatId = 0, int messageId = 0, string inlineMessageId = null,
                                           InlineKeyboardMarkup replyMarkup = null) =>
        EditMessageReplyMarkup(chatId.ToString(), messageId, inlineMessageId, replyMarkup);

        internal void SendPhoto(long chatId, string photo, string caption = null, bool disableNotification = false,
                              int replyToMessageId = 0, object replyMarkup = null) =>
        SendPhoto(chatId.ToString(), photo, caption, disableNotification, replyToMessageId, replyMarkup);

        internal void SendSticker(long chatId, string sticker, bool disableNotification = false,
                                int replyToMessageId = 0, object replyMarkup = null) =>
        SendSticker(chatId.ToString(), sticker, disableNotification, replyToMessageId, replyMarkup);

        internal void SendChatAction(long chatId, ChatAction action) =>
        SendChatAction(chatId.ToString(), action);

        //async versions
        internal async Task SendMessageAsync(long chatId, string text, bool disableWebPagePreview = false,
                                bool disableNotification = false, int replyToMessageId = 0, object replyMarkup = null) =>
        await SendMessageAsync(chatId.ToString(), text, disableWebPagePreview, disableNotification, replyToMessageId, replyMarkup);

        internal async Task EditMessageTextAsync(long chatId, string text, int messageId = 0, string inlineMessageId = null,
                             bool disableWebPagePreview = false, object replyMarkup = null) =>
        await EditMessageTextAsync(chatId.ToString(), text, messageId, inlineMessageId, disableWebPagePreview, replyMarkup);

        internal async Task EditMessageReplyMarkupAsync(long chatId = 0, int messageId = 0, string inlineMessageId = null,
                                           InlineKeyboardMarkup replyMarkup = null) =>
        await EditMessageReplyMarkupAsync(chatId.ToString(), messageId, inlineMessageId, replyMarkup);

        internal async Task SendPhotoAsync(long chatId, string photo, string caption = null, bool disableNotification = false,
                              int replyToMessageId = 0, object replyMarkup = null) =>
        await SendPhotoAsync(chatId.ToString(), photo, caption, disableNotification, replyToMessageId, replyMarkup);

        internal async Task SendStickerAsync(long chatId, string sticker, bool disableNotification = false,
                                int replyToMessageId = 0, object replyMarkup = null) =>
        await SendStickerAsync(chatId.ToString(), sticker, disableNotification, replyToMessageId, replyMarkup);

        internal async Task SendChatActionAsync(long chatId, ChatAction action) =>
        await SendChatActionAsync(chatId.ToString(), action);
        // end

        private void UpdatesThread()
        {
            Logger.LogMessage("Бот запущен.");
            while (isRun)
            {
                var updates = GetUpdates();

                foreach (var update in updates)
				{
                    updateOffset = update.UpdateId + 1;

                    if (update.CallbackQuery != null && OnCallbackQuery != null)
                    {
                        var args = new CallbackQueryEventArgs
                        {
                            CallbackQuery = update.CallbackQuery
                        };

                        OnCallbackQuery(args);
                    }

                    if (update.Message != null && OnMessage != null)
                    {
                        var args = new TelegramMessageEventArgs
                        {
                            ChatId = update.Message.Chat.Id,
                            MessageId = update.Message.MessageId,
                            From = update.Message.From,
                            Message = update.Message
                        };

                        OnMessage(args);
                    }
                    if (update.InlineQuery != null && OnInlineQuery != null)
                    {
                        var args = new InlineQueryEventArgs
                        {
                            InlineQuery = update.InlineQuery
                        };

                        OnInlineQuery(args);
                    }
                }

                System.Threading.Thread.Sleep(1000);
            }
        }

        private Update[] GetUpdates()
        {
            try
            {
                var request = new UpdatesRequest
                {
                    Offset = updateOffset
                };

                var jsonText = api.SendRequest("getUpdates", request);
                var response = JsonConvert.DeserializeObject<Response>(jsonText);
                if (response.Success)
                {
                    return response.Updates;
                }
                else
                {
                    return new Update[0];
                }
            }
            catch (Exception ex)
            {
                isRun = false;
                if (ex is WebException || ex is JsonException)
                {
                    Logger.LogFatal(ex);
                    return new Update[0];
                }
                throw;
            }
        }

        private string EscapeSpecialCharacters(string text)
        {
            var result = text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
            return result;
        }

		internal event TelegramMessageHandler OnMessage;

        internal event InlineQueryHandler OnInlineQuery;

        internal event CallbackQueryHandler OnCallbackQuery;
	}
}