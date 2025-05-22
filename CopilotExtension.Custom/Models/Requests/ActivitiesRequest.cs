using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CopilotExtension.Custom.Models.Requests
{
    public class ActivitiesRequest
    {
        /// <summary>
        /// This input indicates the entity or object type in CRM for which insights are requested.
        /// Allowed values: "account", "opportunity".
        /// </summary>
        [Required(ErrorMessage = "recordType is required.")]
        [JsonPropertyName("recordType")]
        public string recordType { get; set; }

        /// <summary>
        /// This input indicates the unique identifier of the CRM record for which insights are requested.
        /// </summary>
        [Required(ErrorMessage = "recordId is required.")]
        [JsonPropertyName("recordId")]
        public string recordId { get; set; }

        /// <summary>
        /// This input indicates the start date and time for insights requested.
        /// Format: ISO 8601 date-time string.
        /// </summary>
        [JsonPropertyName("startDateTime")]
        public string startDateTime { get; set; }

        /// <summary>
        /// This input indicates the end date and time for insights requested.
        /// Format: ISO 8601 date-time string.
        /// </summary>
        [JsonPropertyName("endDateTime")]
        public string endDateTime { get; set; }

        /// <summary>
        /// This input indicates the number of insights to fetch.
        /// </summary>
        [Range(1, 1000, ErrorMessage = "Top value must be between 1 and 1000.")]
        [JsonPropertyName("top")]
        public int? top { get; set; }

        /// <summary>
        /// This input indicates the number of insights to skip.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Skip value must be a non-negative number.")]
        [JsonPropertyName("skip")]
        public int? skip { get; set; }

        /// <summary>
        /// This input indicates the type of CRM in which the CRM record exists, for which insights are requested.
        /// Allowed values: "Salesforce", "Dynamics365".
        /// </summary>
        [JsonPropertyName("crmType")]
        public string crmType { get; set; }

        /// <summary>
        /// This input indicates the URL of the CRM environment in which the CRM record exists, for which insights are requested.
        /// </summary
        [JsonPropertyName("crmOrgUrl")]
        public string crmOrgUrl { get; set; }
    }
}
