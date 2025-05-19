using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CopilotExtension.Custom.Models.Requests
{
    public class EmailInsightRequest
    {
        /// <summary>
        /// This input indicates a list of all relevant participant emails in the current email thread.
        /// </summary>
        [Required(ErrorMessage = "emailContacts ID is required.")]
        [JsonPropertyName("emailContacts")]
        public string emailContacts { get; set; }

        /// <summary>
        /// This input provides the unique identifier of the CRM record which is related to the summarized email.
        /// </summary>
        [Required(ErrorMessage = "Record ID is required.")]
        [JsonPropertyName("recordId")]
        public string recordId { get; set; }

        /// <summary>
        /// This input identifies the record type in CRM which is related to the summarized email.
        /// </summary>
        [Required(ErrorMessage = "Entity type is required.")]
        [JsonPropertyName("recordType")]
        public string recordType { get; set; }
        /// <summary>
        /// This input indicates the type of CRM in which the record related to the summarized email exists.
        /// </summary>
        [JsonPropertyName("crmType")]
        public string crmType { get; set; }

        /// <summary>
        /// This input indicates the URL of the CRM environment in which the record related to the summarized email exists.
        /// </summary>
        [Url(ErrorMessage = "Invalid CRM Org URL format.")]
        [JsonPropertyName("crmOrgUrl")]
        public string crmOrgUrl { get; set; }

        /// <summary>
        /// This input indicates the number of insights to fetch.
        /// </summary>
        [Range(1, 1000, ErrorMessage = "Top value must be between 1 and 1000.")]
        [JsonPropertyName("top")]
        public int? top { get; set; }

        /// <summary>
        /// This input indicates the number of items to skip when fetching insights.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Skip value must be a non-negative number.")]
        [JsonPropertyName("skip")]
        public int? skip { get; set; }
    }
}
