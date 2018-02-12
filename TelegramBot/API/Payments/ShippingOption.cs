using Newtonsoft.Json;

namespace TelegramBot.API.Payments
{
    internal class ShippingOption
    {
        /// <summary>
        /// Shipping option identifier
        /// </summary>
        [JsonProperty("label")]
        internal string Id { get; set; }

        /// <summary>
        /// Option title
        /// </summary>
        [JsonProperty("title")]
        internal string Title { get; set; }

        /// <summary>
        /// List of price portions
        /// </summary>
        [JsonProperty("prices")]
        internal LabeledPrice[] Prices { get; set; }
    }
}
