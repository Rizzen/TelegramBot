using Newtonsoft.Json;

namespace TelegramBot.API.Models
{
    internal class ApiResponse<T>
    {
        /// <summary>
        /// Gets a value indicating whether the request was successful.
        /// </summary>
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        /// <summary>
        /// Gets the result object.
        /// </summary>
        [JsonProperty("result")]
        public T ResultObject { get; set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        [JsonProperty("description")]
        public string Message { get; set; }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        [JsonProperty("error_code")]
        public int Code { get; set; }

        /// <summary>
        /// Contains information about why a request was unsuccessfull.
        /// </summary>
        [JsonProperty("parameters")]
        public ResponseParameters Parameters { get; set; }
    }
}
