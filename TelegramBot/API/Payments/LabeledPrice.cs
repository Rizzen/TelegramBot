using Newtonsoft.Json;

namespace TelegramBot.API.Payments
{
    internal class LabeledPrice
    {
        /// <summary>
        /// Portion label
        /// </summary>
        [JsonProperty("label")]
        internal string Label { get; set; }

        /// <summary>
        /// Price of the product in the smallest units of the currency (integer, not float/double). 
        /// For example, for a price of US$ 1.45 pass amount = 145. 
        /// See the exp parameter in currencies.json, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
        /// </summary>
        [JsonProperty("amount")]
        internal int Amount { get; set; }
    }
}
