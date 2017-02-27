using System;
using System.IO;
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

        public void SendMessage(long chatId, string text, int replayToMessageId = 0)
        {
            var message = new MessageToSend
            {
                ChatId = chatId,
                Text = text,
                ReplayToMessageId = replayToMessageId
            };

            api.SendRequest("sendMessage", message);
        }

        public void SendPhoto(long chatId, string url, string caption = "", int replayToMessageId = 0)
        {
            var photo = new PhotoToSend
            {
                ChatId = chatId,
                PhotoUrl = url,
                Caption = caption,
                ReplayToMessageId = replayToMessageId
            };

            api.SendRequest("sendPhoto", photo);
		}

        public void SendSticker(long chatId, string sticker, int replayToMessageId = 0)
        {
            var stickerw = new StickerToSend
            {
                ChatId = chatId,
                Sticker = sticker,
                ReplayToMessageId = replayToMessageId
            };

            api.SendRequest("sendSticker", stickerw);
        }

        private void UpdatesThread()
        {
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
            catch (WebException e)
            {
                Console.WriteLine(e);
                return new Update[0];
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
                return new Update[0];
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