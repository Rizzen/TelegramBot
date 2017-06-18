using Newtonsoft.Json;

namespace TelegramBot.API.Payments
{
    class ShippingAddress
    {
        /// <summary>
        /// ISO 3166-1 alpha-2 country code
        /// </summary>
        [JsonProperty("country_code")]
        internal string CountryCode { get; set; }

        /// <summary>
        /// State, if applicable
        /// </summary>
        [JsonProperty("state")]
        internal string State { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonProperty("city")]
        internal string City { get; set; }

        /// <summary>
        /// First line for the address
        /// </summary>
        [JsonProperty("street_line1")]
        internal string StreetLine1 { get; set; }

        /// <summary>
        /// Second line for the address
        /// </summary>
        [JsonProperty("street_line2")]
        internal string StreetLine2 { get; set; }

        /// <summary>
        /// Address post code
        /// </summary>
        [JsonProperty("post_code")]
        internal string PostCode { get; set; }
    }
}
