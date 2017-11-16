using System;
using System.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using TelegramBot.API;
using Newtonsoft.Json;
using TelegramBot.API.Types;

namespace TelegramBot
{
    [Obsolete]
    internal class SimpleBot
    {
        const string TOKEN = @"437367398:AAEE6VZNK7LOEBcyJiKpR2_o6LMGGUSTyV8";
        const string URI = @"https://api.telegram.org/bot";
        const string GETUPDATES = @"/getUpdates";

        private ApiClient _apiClient;

        private int _updateId = 0;

        public SimpleBot()
        {
            _apiClient = new ApiClient(TOKEN);
        }

        public Task StartBot()
        {
            while (true)
            {
                Task.Delay(1000);
                GetUpdates();
                
            }
        }


        public void GetUpdates ()
        {
            var request = (HttpWebRequest)WebRequest.Create($"{URI}{TOKEN}{GETUPDATES}?offset={_updateId+1}");
            var resp = (HttpWebResponse)request.GetResponse();

            var sReader = new StreamReader(resp.GetResponseStream());

            var responsedJson = sReader.ReadToEnd();

            try
            {
                var currentUpdate = JsonConvert.DeserializeObject<Responce>(responsedJson);
                //for test
                if (currentUpdate.Updates.Any())
                {
                    Console.WriteLine($"Update #{_updateId}");
                
                    foreach (var current in currentUpdate.Updates)
                    {
                        _updateId = current.UpdateId;
                        string messageText;
                        messageText = current.Message != null
                            ? current.Message.Text
                            : current.EditedMessage.Text;
                        Console.WriteLine(messageText);
                    }
                }
        }
            catch (Exception e)
            {
                Console.WriteLine($"Update Failed {e.Message}");
            }
        }

        public async Task GetUpdatesAsynс()
        {
            await Task.Run(() =>
            {
                GetUpdates();
            });
        }
    }
}
