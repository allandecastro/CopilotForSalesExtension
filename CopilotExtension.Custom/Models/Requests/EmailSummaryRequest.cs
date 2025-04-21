using CopilotExtension.Custom.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace CopilotExtension.Custom.Models.Requests
{
    public class EmailSummaryRequest
    {
        /// <summary>
        /// The resource data to be used for fetching the suggested content.
        /// This input identifies the email content which is a collection of email thread, subject, and other details.
        /// </summary>
        [Required(ErrorMessage = "Resource data is required.")]
        public ResourceData resourceData { get; set; }

        /// <summary>
        /// The array of related entities.
        /// This input identifies the array of CRM records, which is related to the email thread.
        /// </summary>
        public List<RelatedEntity> relatedEntities { get; set; }

        /// <summary>
        /// CRM type (e.g., "Dynamics", "Salesforce").
        /// Optional: The CRM type for the system you're integrating with.
        /// </summary>
        public string crmType { get; set; }

        /// <summary>
        /// URL of the CRM organization (e.g., "https://org.crm.dynamics.com").
        /// Optional: The full URL to the CRM organization.
        /// </summary>
        [Url(ErrorMessage = "Invalid CRM Org URL format.")]
        public string crmOrgUrl { get; set; }

        /// <summary>
        /// Optional: Number of records to return. Must be between 1 and 1000.
        /// </summary>
        [Range(1, 1000, ErrorMessage = "Top value must be between 1 and 1000.")]
        public int? top { get; set; }

        /// <summary>
        /// Optional: Number of records to skip (for pagination). Must be a non-negative number.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Skip value must be a non-negative number.")]
        public int? skip { get; set; }
    }


    public class RelatedEntity
    {
        /// <summary>
        /// The unique identifier of the CRM record that is related to the email thread.
        /// </summary>
        [Required(ErrorMessage = "Entity ID is required.")]
        public string entityId { get; set; }

        /// <summary>
        /// The type of CRM record such as account or opportunity.
        /// </summary>
        [Required(ErrorMessage = "Entity type is required.")]
        public string entityType { get; set; }

        /// <summary>
        /// This input indicates the entity source, currently contains "connected" or empty values.
        /// </summary>
        public string entitySource { get; set; }
    }
}
