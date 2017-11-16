using Newtonsoft.Json;
using TelegramBot.API.Types;

namespace TelegramBot.API.Payments
{
    internal class PreCheckoutQuery
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
        /// Three-letter ISO 4217 currency code
        /// </summary>
        [JsonProperty("currency")]
        internal string Currency { get; set; }

        /// <summary>
        /// Total price in the smallest units of the currency (integer, not float/double).
        /// For example, for a price of US$ 1.45 pass amount = 145.
        /// See the exp parameter in currencies.json, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
        /// </summary>
        [JsonProperty("total_amount")]
        internal string TotalAmount { get; set; }

        /// <summary>
        /// Bot specified invoice payload
        /// </summary>
        [JsonProperty("invoice_payload")]
        internal string InvoicePayload { get; set; }

        /// <summary>
        /// Optional. Identifier of the shipping option chosen by the user
        /// </summary>
        [JsonProperty("shipping_option_id")]
        internal string ShippingOptionsId { get; set; }

        /// <summary>
        /// Optional. Order info provided by the user
        /// </summary>
        [JsonProperty("order_info")]
        internal OrderInfo OrderInfo { get; set; }
    }
}
