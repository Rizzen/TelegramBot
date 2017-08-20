using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Serializers;

namespace TelegramBot.Utils
{
    /// <summary> ISerializer baseb on Newtonsoft.Json </summary>
    public class NewtonsoftJsonSerializer: ISerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer _serializer;

        public NewtonsoftJsonSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            _serializer = serializer;
        }

        public string Serialize(object obj)
        {
            using (var sw = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(sw))
                {
                    _serializer.Serialize(jsonTextWriter, obj);

                    return sw.ToString();
                }
            }
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public string ContentType
        {
            get { return "application/json"; }
            set { }
        }

        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            var content = response.Content;
            using (var sr = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    return _serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }

        public static NewtonsoftJsonSerializer Default => new NewtonsoftJsonSerializer(new Newtonsoft.Json.JsonSerializer()
        {
            NullValueHandling = NullValueHandling.Ignore
        });
    }
}
