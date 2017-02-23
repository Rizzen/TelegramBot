/*
 * Осторожно, весь бот расположен в одном файле, чтобы не плодить кучу файлов для личных целей
 * Также завёл отдельный неймспейс под это дело, а то у других будет куча ненужных для них классов
*/

using System;
using System.Net;

using Newtonsoft.Json;
using TelegramBot.API_Classes;

namespace TelegramBot.NyaBot
{
	public class NyanBot
	{
		private const string BASE_API_ADDRESS = @"https://api.telegram.org/bot";

		private string token = String.Empty;
		private bool isRun = false;
		private int updateOffset = 0;

		public NyanBot(string token)
		{
			this.token = token;
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

		public void SendMessage(long chatId, string text)
		{
			if (chatId < 1 || text.Length < 1)
			{
				return;
			}

			using (WebClient client = new WebClient())
			{
				try
				{
					client.DownloadString($"{BASE_API_ADDRESS}{token}/sendMessage?chat_id={chatId}&text={text}");
				}
				catch (WebException e)
				{
					Console.WriteLine(e);
				}
			}
		}

		private void UpdatesThread()
		{
			var client = new WebClient();

			while (isRun)
			{
				string jsonText = null;
				try
				{
					jsonText = client.DownloadString($"{BASE_API_ADDRESS}{token}/getUpdates?offset={updateOffset}");
				}
				catch (WebException e)
				{
					Console.WriteLine(e);
				}

				Response response = null;
				try
				{
					response = JsonConvert.DeserializeObject<Response>(jsonText);
				}
				catch (JsonException e)
				{
					Console.WriteLine(e);
					continue;
				}

				if (!response.Success)
				{
					continue;
				}

				foreach (var update in response.Updates)
				{
					updateOffset = update.UpdateId + 1;

					if (update.Message != null && OnMessage != null)
					{
						var args = new TelegramMessageEventArgs
						{
							From = update.Message.From,
							Message = update.Message
						};

						OnMessage(args);
					}
				}

				System.Threading.Thread.Sleep(1000);
			}
		}

		internal event TelegramMessageHandler OnMessage;
	}

	// Handlers
	internal delegate void TelegramMessageHandler(TelegramMessageEventArgs args);

	// EventArgs
	internal class TelegramMessageEventArgs : EventArgs
	{
		public User From { get; set; }
		public Message Message { get; set; }
	}
}