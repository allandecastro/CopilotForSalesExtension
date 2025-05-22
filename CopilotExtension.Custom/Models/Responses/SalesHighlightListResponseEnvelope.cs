using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CopilotExtension.Custom.Models.Responses
{

    public class SalesHighlightListResponseEnvelope
    {
        /// <summary>
        /// A collection of insights that describe details related to an email or a related activity.
        /// </summary>
        [Required]
        public List<SalesHighlight> value { get; set; }

        /// <summary>
        /// A value that indicates whether more results are available.
        /// </summary>
        public bool hasMoreResults { get; set; }
    }

    /// <summary>
    /// Represents a single insight related to an email or CRM activity, including metadata and additional context.
    /// </summary>
    public class SalesHighlight
    {
        /// <summary>
        /// This output indicates the text of the insight to be included in key sales info.
        /// </summary>
        [JsonPropertyName("description")]
        [MinLength(1)]
        public string description { get; set; }

        /// <summary>
        /// This output indicates the title of citation card for the insight.
        /// </summary>
        [JsonPropertyName("title")]
        [MinLength(1)]
        public string title { get; set; }

        /// <summary>
        /// This output indicates the time associated with the insight.
        /// </summary>
        [JsonPropertyName("dateTime")]
        public string dateTime { get; set; }

        /// <summary>
        /// This output indicates the URL to learn more about the insight.
        /// </summary>
        [JsonPropertyName("url")]
        public string url { get; set; }

        /// <summary>
        /// This output indicates additional properties as name-value pairs of each related insight returned by the action.
        /// </summary>
        [JsonPropertyName("additionalProperties")]
        public Dictionary<string, string> additionalProperties { get; set; }
    }
}