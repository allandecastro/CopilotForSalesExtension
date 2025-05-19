using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopilotExtension.Custom.Models.Responses
{
    /// <summary>
    /// Represents the response structure for an email summary, containing a list of insights and a flag indicating if there are more results.
    /// </summary>
    public class EmailSummaryResponse
    {
        /// <summary>
        /// A collection of insights that describe details related to an email or a related activity.
        /// </summary>
        [Required]
        public List<Insight> value { get; set; }

        /// <summary>
        /// A value that indicates whether more results are available.
        /// </summary>
        public bool hasMoreResults { get; set; }
    }

    /// <summary>
    /// Represents a single insight related to an email or CRM activity, including metadata and additional context.
    /// </summary>
    public class Insight
    {
        /// <summary>
        /// This output indicates the text you would like to be included in the email summary.
        /// </summary>
        [Required]
        public string insight { get; set; }

    }
}