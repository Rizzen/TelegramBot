using System;
using System.Net;
using System.IO;

namespace TelegramBot
{

    // TODO: вынести в отдельный файл и испрвить проверку ссылок
    class FileDownloader
    {
        public bool IsFileLink(string link)
        {
            if (link.StartsWith("http"))
            {
                string format;
                if ((format = Path.GetExtension(link)) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void DownloadFile(string link)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(link, Path.GetFileName(link));
                    Console.WriteLine($"Файл загружен: {Path.GetFileName(link)}");
                }
                catch (WebException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }

}
