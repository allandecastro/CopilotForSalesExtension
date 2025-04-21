using System.ComponentModel.DataAnnotations;

namespace CopilotExtension.Custom.Models.Requests
{
    /// <summary>
    /// Represents the request parameters for enriching CRM record details.
    /// This model is used by the Copilot for Sales integration to request additional insights for CRM records.
    /// </summary>
    public class CrmRecordDetailRequest
    {
        /// <summary>
        /// The type of entity or object in CRM that related insights are requested for.
        /// Example values: "account", "opportunity", "contract".
        /// </summary>
        [Required(ErrorMessage = "RecordType is required.")]
        public string recordType { get; set; }

        /// <summary>
        /// The unique identifier of the CRM record for which insights are requested.
        /// </summary>
        [Required(ErrorMessage = "RecordId is required.")]
        public string recordId { get; set; }


        /// <summary>
        /// Optional. Limits the number of insights returned.
        /// Must be between 1 and 1000 if specified.
        /// </summary>
        [Range(1, 1000, ErrorMessage = "Top value must be between 1 and 1000.")]
        public int? top { get; set; }

        /// <summary>
        /// Optional. The number of insights to skip, typically used for pagination.
        /// Must be a non-negative number.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Skip value must be a non-negative number.")]
        public int? skip { get; set; }

        /// <summary>
        /// Optional. The type of CRM system making the request (e.g., "Dynamics365", "Salesforce").
        /// Helps distinguish source systems if needed.
        /// </summary>
        public string? crmType { get; set; }

        /// <summary>
        /// Optional. The URL of the CRM organization making the request.
        /// Validates as a well-formed URL.
        /// Example: https://yourorg.crm.dynamics.com
        /// </summary>
        [Url(ErrorMessage = "Invalid CRM Org URL format.")]
        public string? crmOrgUrl { get; set; }

    }
}