using System.Net;
using System.IO;

namespace TelegramBot
{
    class SimpleBot
    {
        const string TOKEN = @"375416144:AAHDLsJ_0MOow-u_LbwdWqRvfB4uyRByryQ";

        void GetUpdates()
        {
            HttpWebRequest requestToApi = (HttpWebRequest)WebRequest.Create("https://api.telegram.org/bot" + TOKEN + "/getUpdates");
            HttpWebResponse responseAtApi = (HttpWebResponse)requestToApi.GetResponse();
            using (StreamReader sreader = new StreamReader(responseAtApi.GetResponseStream()))
            {
                System.Console.WriteLine(sreader.ReadToEnd());
            }

            System.Console.ReadLine();
        }

    }
}
