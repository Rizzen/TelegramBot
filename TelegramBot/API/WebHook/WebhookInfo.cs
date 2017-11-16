using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TelegramBot.API.WebHook
{
    public class WebhookInfo
    {
        /// <summary>Webhook URL, may be empty if webhook is not set up</summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        
        /// <summary>True, if a custom certificate was provided for webhook certificate checks</summary>
        [JsonProperty("has_custom_certificate")]
        public bool HasCustomCertificate { get; set; }

        /// <summary>Number of updates awaiting delivery</summary>
        [JsonProperty("pending_update_count")]
        public int PendingUpdateCount { get; set; }

        /// <summary>Optional. Unix time for the most recent error that happened when trying to deliver an update via webhook</summary>
        [JsonProperty("last_error_date")]
        public int LastErrorDate { get; set; }

        /// <summary>Optional. Error message in human-readable format for the most recent error that happened when trying to deliver an update via webhook</summary>
        [JsonProperty("last_error_message")]
        public string LastErrorMessage { get; set; }

        /// <summary>Optional. Maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery</summary>
        [JsonProperty("max_connections")]
        public int MaxConnections { get; set; }

        /// <summary>Optional. A list of update types the bot is subscribed to. Defaults to all update types</summary>
        [JsonProperty("allowed_updates")]
        public string[] AllowedUpdates { get; set; }
    }
}
