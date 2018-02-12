using Newtonsoft.Json;

namespace TelegramBot.API.InlineMode.InputMessageContents
{
    internal class InputContactMessageContent : InputMessageContent
    {
        //Contact's phone number
        [JsonProperty("phone_number")]
        internal string PhoneNumber { get; set; }

        //Contact's first name
        [JsonProperty("first_name")]
        internal string FirstName { get; set; }

        //Optional. Contact's last name
        [JsonProperty("last_name")]
        internal string LastName { get; set; }

    }
}
