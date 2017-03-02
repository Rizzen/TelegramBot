using System;
using System.Net;

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

        public NyanBot(string token)
        {
            api = new BotApiClient(token);
        }

        public void Start()
        {
            isRun = true;
            UpdatesThread();
        }

        public void Stop()
        {
            isRun = false;
        }

        public bool IsRun => isRun;

        public void SendMessage(long chatId, string text, bool disableWebPagePreview = false,
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

        public void SendPhoto(long chatId, string photo, string caption = null, bool disableNotification = false,
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

        public void SendSticker(long chatId, string sticker, bool disableNotification = false,
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

        internal void SendChatAction(long chatId, ChatAction action)
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

            api.DownloadString($"sendChatAction?chat_id={chatId.ToString()}&action={actionString}");
        }

        private void UpdatesThread()
        {
            Logger.LogMessage("Бот запущен.");
            while (isRun)
            {
                var updates = GetUpdates();

                foreach (var update in updates)
				{
                    updateOffset = update.UpdateId + 1;

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
                }

                System.Threading.Thread.Sleep(1000);
            }
        }

        private Update[] GetUpdates()
        {
            try
            {
                var jsonText = api.DownloadString($"getUpdates?offset={updateOffset}");
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
	}
}