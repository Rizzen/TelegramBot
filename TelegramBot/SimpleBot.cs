using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TelegramBot.API_Classes;
using System.Threading;

namespace TelegramBot
{
    class SimpleBot
    {
        const string TOKEN = @"375416144:AAHDLsJ_0MOow-u_LbwdWqRvfB4uyRByryQ";
        const string URI = @"https://api.telegram.org/bot";
        //static int UpdateID = 0; 

        public SimpleBot()
        {
            while (true)
            {
                GetUpdates();
                //Thread.Sleep(1000);
            }
        }

        void GetUpdates()
        {
            var req = (HttpWebRequest)WebRequest.Create(URI + TOKEN + "/getUpdates");
            //Console.WriteLine("{0}", UpdateID + 1);
            var resp = (HttpWebResponse)req.GetResponse();


            using (var sReader = new StreamReader(resp.GetResponseStream()))
            {
                string responsedJson = sReader.ReadToEnd();
                Console.WriteLine(responsedJson);

                // List<MyStok> myDeserializedObjList = (List<MyStok>)Newtonsoft.Json.JsonConvert.DeserializeObject(sc), typeof(List<MyStok>));

                //Update[] currentUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<Update[]>(responsedJson);//эксепшн
                // List<Update> currentUpdate = (List<Update>)Newtonsoft.Json.JsonConvert.DeserializeObject<List<Update>>(responsedJson);
                Update[] currentUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<Update[]>(responsedJson);
                sReader.Close();
                Console.WriteLine(currentUpdate[0].UpdateId);
                Console.ReadLine();
                
            }


            //Console.ReadLine();
        }

        //void MakeRequest(string method)
        //{
        //    var req = (HttpWebRequest)WebRequest.Create(URI + TOKEN + method);
        //    var resp = (HttpWebResponse)req.GetResponse();


        //}
    }
}
