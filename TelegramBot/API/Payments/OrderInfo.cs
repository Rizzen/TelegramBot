using Newtonsoft.Json;

namespace TelegramBot.API.Payments
{
    internal class OrderInfo
    {
        /// <summary>
        /// Optional. User name
        /// </summary>
        [JsonProperty("name")]
        internal string Name { get; set; }

        /// <summary>
        /// Optional. User's phone number
        /// </summary>
        [JsonProperty("phone_number")]
        internal string PhoneNumber { get; set; }

        /// <summary>
        /// Optional. User email
        /// </summary>
        [JsonProperty("email")]
        internal string Email { get; set; }

        /// <summary>
        /// Optional. User shipping address
        /// </summary>
        [JsonProperty("shipping_address")]
        internal ShippingAddress ShippingAddress { get; set; }
    }
}
