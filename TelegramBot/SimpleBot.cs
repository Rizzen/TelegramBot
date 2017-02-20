using System.Net;

namespace TelegramBot
{
    class SimpleBot
    {
        const string TOKEN = @"375416144:AAHDLsJ_0MOow-u_LbwdWqRvfB4uyRByryQ";

        void GetUpdates()
        {
            HttpWebRequest requestToApi = (HttpWebRequest)WebRequest.Create("https://api.telegram.org/bot" + TOKEN + "/getUpdates()");
            HttpWebResponse responseAtApi = (HttpWebResponse)requestToApi.GetResponse();
            System.IO.StreamReader reader = new System.IO.StreamReader(responseAtApi.GetResponseStream());
            System.Console.WriteLine(reader.ReadToEnd());
            System.Console.ReadLine();
        }

    }
}
