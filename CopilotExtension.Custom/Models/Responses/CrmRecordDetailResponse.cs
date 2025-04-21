using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopilotExtension.Custom.Models.Responses
{
    /// <summary>
    /// Represents the response for enriching CRM record details.
    /// This model is used by the Copilot for Sales integration to return enriched CRM record data.
    /// </summary>
    public class CrmRecordDetailResponse
    {
        /// <summary>
        /// A list of enriched insights for the CRM record.
        /// </summary>
        [Required(ErrorMessage = "The 'Value' field is required.")]
        public List<InsightRecordDetailResponse> value { get; set; }

        /// <summary>
        /// Indicates whether there are more results available for pagination.
        /// </summary>
        [Required(ErrorMessage = "The 'HasMoreResults' field is required.")]
        public bool hasMoreResults { get; set; }

        /// <summary>
        /// Represents an individual insight related to the CRM record.
        /// </summary>
        public class InsightRecordDetailResponse
        {
            /// <summary>
            /// The unique identifier for the record.
            /// </summary>
            [Required(ErrorMessage = "RecordId is required.")]
            public string recordId { get; set; }

            /// <summary>
            /// The display name of the record type (e.g., "Contract", "Opportunity").
            /// </summary>
            [Required(ErrorMessage = "RecordTypeDisplayName is required.")]
            public string recordTypeDisplayName { get; set; }

            /// <summary>
            /// The plural display name for the record type (e.g., "Contracts", "Opportunities").
            /// </summary>
            [Required(ErrorMessage = "RecordTypePluralDisplayName is required.")]
            public string recordTypePluralDisplayName { get; set; }

            /// <summary>
            /// The type of the record (e.g., "contract", "opportunity").
            /// </summary>
            [Required(ErrorMessage = "RecordType is required.")]
            public string recordType { get; set; }
            /// <summary>
            /// The title or name of the record.
            /// </summary>
            [Required(ErrorMessage = "RecordTitle is required.")]
            public string recordTitle { get; set; }

            /// <summary>
            /// The URL linking to the record details.
            /// </summary>
            [Url(ErrorMessage = "Invalid URL format.")]
            public string url { get; set; }

            /// <summary>
            /// A dictionary to store additional properties related to the record.
            /// </summary>
            public Dictionary<string, string> additionalProperties { get; set; }
        }
    }
}