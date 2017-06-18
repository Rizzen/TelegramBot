using Newtonsoft.Json;

namespace TelegramBot.API.Payments
{
    internal class ShippingQuery
    {
        /// <summary>
        /// Unique query identifier
        /// </summary>
        [JsonProperty("id")]
        internal string Id { get; set; }

        /// <summary>
        /// User who sent the query
        /// </summary>
        [JsonProperty("from")]
        internal User From { get; set; }

        /// <summary>
        /// Bot specified invoice payload
        /// </summary>
        [JsonProperty("invoice_payload")]
        internal string InvoicePayload { get; set; }

        /// <summary>
        /// User specified shipping address
        /// </summary>
        [JsonProperty("shipping_address")]
        internal ShippingAddress ShippingAddress { get; set; }
    }
}
