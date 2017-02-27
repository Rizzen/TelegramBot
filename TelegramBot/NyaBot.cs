/*
 * Осторожно, весь бот расположен в одном файле, чтобы не плодить кучу файлов для личных целей
 * Также завёл отдельный неймспейс под это дело, а то у других будет куча ненужных для них классов
*/

using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TelegramBot.API_Classes;

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

    internal class MessageToSend
    {
        [JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("reply_to_message_id")]
        public int ReplayToMessageId { get; set; }
    }

    internal class PhotoToSend
    {
        [JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [JsonProperty("photo")]
        public string PhotoUrl { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("reply_to_message_id")]
        public int ReplayToMessageId { get; set; }
    }

    internal class StickerToSend
    {
        [JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [JsonProperty("sticker")]
        public string Sticker { get; set; }

        [JsonProperty("reply_to_message_id")]
        public int ReplayToMessageId { get; set; } 
    }

    internal class BotApiClient
    {
        const string BASE_API_ADDRESS = @"https://api.telegram.org/bot";

        private string token;

        public BotApiClient(string token)
        {
            this.token = token;
        }

        public void SendRequest(string methodName, object o)
        {
            HttpWebResponse response = null;
            StreamWriter streamWriter = null;

            try
            {
                var jsonText = JsonConvert.SerializeObject(o);

                var webRequest = (HttpWebRequest)WebRequest.Create($"{BASE_API_ADDRESS}{token}/{methodName}");
                webRequest.ContentType = "application/json";
                webRequest.Method = "POST";

                using (streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonText);
                }

                response = (HttpWebResponse)webRequest.GetResponse();
                // добавить сюда получение ответа, если он нужен
                response.Close();
            }
            catch (Exception e)
            {
                streamWriter?.Dispose();
                response?.Dispose();
                Console.WriteLine(e);
            }
        }

        public string DownloadString(string method)
        {
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            string result = String.Empty;

            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create($"{BASE_API_ADDRESS}{token}/{method}");
                response = (HttpWebResponse)webRequest.GetResponse();

                using (streamReader = new StreamReader(response.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            response?.Dispose();
            streamReader?.Dispose();

            return result;
        }
    }

	// Handlers
    internal delegate void TelegramMessageHandler(TelegramMessageEventArgs a);

	// EventArgs
    internal class TelegramMessageEventArgs : EventArgs
    {
        public long ChatId { get; set; }
        public int MessageId { get; set; }
        public User From { get; set; }
        public Message Message { get; set; }
    }
}