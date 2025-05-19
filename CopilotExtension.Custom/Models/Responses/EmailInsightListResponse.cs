using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CopilotExtension.Custom.Models.Responses
{
    /// <summary>
    /// Represents the response structure for an email summary, containing a list of insights and a flag indicating if there are more results.
    /// </summary>
    public class EmailInsightListResponse
    {
        /// <summary>
        /// A collection of insights that describe details related to an email or a related activity.
        /// </summary>
        [Required]
        public List<EmailInsight> value { get; set; }

        /// <summary>
        /// A value that indicates whether more results are available.
        /// </summary>
        public bool hasMoreResults { get; set; }
    }

    /// <summary>
    /// Represents a single insight related to an email or CRM activity, including metadata and additional context.
    /// </summary>
    public class EmailInsight
    {
        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }
    }
}