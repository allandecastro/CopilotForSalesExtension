using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CopilotExtension.Custom.Models.Requests
{
    public class RecordDetailsRequest
    {
        /// <summary>
        /// This input identifies the record type in CRM for which related records are requested.
        /// Allowed values: "account", "opportunity".
        /// </summary>
        [Required(ErrorMessage = "recordType is required.")]
        [JsonPropertyName("recordType")]
        [EnumDataType(typeof(RecordTypeEnum), ErrorMessage = "Allowed values are: account, opportunity.")]
        public string recordType { get; set; }

        /// <summary>
        /// This input provides the unique identifier of the CRM record for which related records are requested.
        /// </summary>
        [Required(ErrorMessage = "recordId is required.")]
        [JsonPropertyName("recordId")]
        public string recordId { get; set; }

        /// <summary>
        /// This input indicates the number of related records to fetch.
        /// </summary>
        [Range(1, 1000, ErrorMessage = "Top value must be between 1 and 1000.")]
        [JsonPropertyName("top")]
        public int? top { get; set; }

        /// <summary>
        /// This input indicates the number of records to skip when fetching related records.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Skip value must be a non-negative number.")]
        [JsonPropertyName("skip")]
        public int? skip { get; set; }

        /// <summary>
        /// This input indicates the type of CRM the related records are fetched from.
        /// Allowed values: "Salesforce", "Dynamics365".
        /// </summary>
        [JsonPropertyName("crmType")]
        [EnumDataType(typeof(CrmTypeEnum), ErrorMessage = "Allowed values are: Salesforce, Dynamics365.")]
        public string crmType { get; set; }

        /// <summary>
        /// This input indicates the URL of the CRM environment the related records are fetched from.
        /// </summary>
        [JsonPropertyName("crmOrgUrl")]
        public string crmOrgUrl { get; set; }
    }

    public enum RecordTypeEnum
    {
        account,
        opportunity
    }

    public enum CrmTypeEnum
    {
        Salesforce,
        Dynamics365
    }
}
