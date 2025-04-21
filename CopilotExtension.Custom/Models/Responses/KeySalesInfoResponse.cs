using System.ComponentModel.DataAnnotations;

namespace CopilotExtension.Custom.Models.Responses
{
    public class KeySalesInfoResponse
    {
        /// <summary>
        /// List of activities.
        /// </summary>
        [Required]
        public List<Activity> value { get; set; } = [];

        /// <summary>
        /// Indicates whether there are more results.
        /// </summary>
        public bool hasMoreResults { get; set; }
    }

    public class Activity
    {
        /// <summary>
        /// Title of the activity.
        /// </summary>
        [Required]
        public string title { get; set; }

        /// <summary>
        /// Description of the activity.
        /// </summary>
        [Required]
        public string description { get; set; }

        /// <summary>
        /// Date and time of the activity.
        /// </summary>
        public DateTime dateTime { get; set; }

        /// <summary>
        /// URL related to the activity.
        /// </summary>
        [Url]
        public string url { get; set; }

        /// <summary>
        /// A dictionary of additional properties associated with the file.
        /// This could include custom metadata or additional information that is not part of the main content.
        /// </summary>
        public Dictionary<string, string> additionalProperties { get; set; }
    }
}