using CopilotExtension.Custom.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace CopilotExtension.Custom.Models.Requests
{

    /// <summary>
    /// Represents the request structure for an enriched email draft.
    /// Contains resource data, resource type, and additional filters like record type and CRM details.
    /// </summary>
    public class EmailDraftRequest
    {
        /// <summary>
        /// Gets or sets the resource data required for the email draft request.
        /// </summary>
        [Required(ErrorMessage = "ResourceData is required.")]
        public ResourceData resourceData { get; set; }

        /// <summary>
        /// Gets or sets the resource type (e.g., email, appointment).
        /// </summary>
        [Required(ErrorMessage = "ResourceType is required.")]
        public string resourceType { get; set; }

        /// <summary>
        /// Gets or sets the record type (optional).
        /// </summary>
        public string recordType { get; set; }

        /// <summary>
        /// Gets or sets the record ID associated with the request.
        /// </summary>
        public string recordId { get; set; }

        /// <summary>
        /// Gets or sets the CRM type (e.g., Dynamics 365, Salesforce).
        /// </summary>
        public string crmType { get; set; }

        /// <summary>
        /// Gets or sets the URL of the CRM organization.
        /// </summary>
        [Url(ErrorMessage = "Invalid CRM Org URL format.")]
        public string crmOrgUrl { get; set; }

        /// <summary>
        /// Gets or sets the input prompt that can be used for custom inputs.
        /// </summary>
        public string inputPrompt { get; set; }

        /// <summary>
        /// Gets or sets the "Top" parameter, which specifies the maximum number of records to return.
        /// Valid values range from 1 to 1000.
        /// </summary>
        [Range(1, 1000, ErrorMessage = "Top value must be between 1 and 1000.")]
        public int? top { get; set; }

        /// <summary>
        /// Gets or sets the "Skip" parameter, which specifies the number of records to skip for pagination.
        /// Must be a non-negative number.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Skip value must be a non-negative number.")]
        public int? skip { get; set; }
    }
}