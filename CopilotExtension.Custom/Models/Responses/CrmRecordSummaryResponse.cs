using System.ComponentModel.DataAnnotations;

namespace CopilotExtension.Custom.Models
{

    public class CrmRecordSummaryResponse
    {
        /// <summary>
        /// List of insight summaries.
        /// </summary>
        [Required]
        public List<InsightRecordSummaryResponse> value { get; set; }

        /// <summary>
        /// Indicates if there are more results to fetch.
        /// </summary>
        public bool hasMoreResults { get; set; }
    }

    public class InsightRecordSummaryResponse
    {
        /// <summary>
        /// The title of the insight record.
        /// </summary>
        [Required]
        public string title { get; set; }

        /// <summary>
        /// A brief description of the insight.
        /// </summary>
        [Required]
        public string description { get; set; }

        /// <summary>
        /// Optional: A date and time associated with the insight.
        /// </summary>
        public DateTime? dateTime { get; set; }

        /// <summary>
        /// Optional: A URL pointing to more information about the insight.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Optional: Additional properties to enrich the insight.
        /// </summary>
        public Dictionary<string, string> additionalProperties { get; set; }
    }
}
