using Newtonsoft.Json;

namespace TelegramBot.API.Payments
{
    internal class Invoice
    {
        /// <summary>
        /// Product name
        /// </summary>
        [JsonProperty("title")]
        internal string Title { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        [JsonProperty("description")]
        internal string Description { get; set; }

        /// <summary>
        /// Unique bot deep-linking parameter that can be used to generate this invoice
        /// </summary>
        [JsonProperty("start_parameter")]
        internal string StartParameter { get; set; }

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
        internal int TotalAmount { get; set; }
    }
}
