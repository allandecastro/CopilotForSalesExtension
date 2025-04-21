using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CopilotExtension.Custom.Models.Requests
{
    /// <summary>
    /// Represents a request to retrieve key sales information.
    /// </summary>
    public class KeySalesInfoRequest
    {
        /// <summary>
        /// Type of the record (e.g., "account", "contact").
        /// </summary>
        [Required(ErrorMessage = "RecordType is required.")]
        public string recordType { get; set; }

        /// <summary>
        /// ID of the record.
        /// </summary>
        [Required(ErrorMessage = "RecordId is required.")]
        public string recordId { get; set; }

        /// <summary>
        /// CRM type (e.g., "Dynamics", "Salesforce").
        /// Optional: The CRM type for the system you're integrating with.
        /// </summary>
        public string? crmType { get; set; }

        /// <summary>
        /// URL of the CRM organization (e.g., "https://org.crm.dynamics.com").
        /// Optional: The full URL to the CRM organization.
        /// </summary>
        [Url(ErrorMessage = "Invalid CRM Org URL format.")]
        public string? crmOrgUrl { get; set; }

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
}