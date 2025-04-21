using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopilotExtension.Custom.Models.Responses
{
    /// <summary>
    /// Represents the response structure for email drafts.
    /// </summary>
    public class EmailDraftResponse
    {
        /// <summary>
        /// A list of file links associated with the email draft.
        /// Each item in the list contains information about a file attached to the email draft.
        /// </summary>
        public List<FileLink> value { get; set; }

        /// <summary>
        /// Indicates whether there are more results available for pagination.
        /// If true, there are additional results that can be retrieved.
        /// </summary>
        public bool hasMoreResults { get; set; }
    }

    /// <summary>
    /// Represents a file link associated with an email draft.
    /// </summary>
    public class FileLink
    {
        /// <summary>
        /// Gets or sets the content type of the file (e.g., application/pdf, image/jpeg).
        /// </summary>
        [Required]
        public string contentType { get; set; }

        /// <summary>
        /// Gets or sets the base64-encoded content of the file.
        /// This could represent the actual file content in a textual form.
        /// </summary>
        [Required]
        public string content { get; set; }

        /// <summary>
        /// Gets or sets the title of the content associated with the file.
        /// This could be the name of the file or a relevant title.
        /// </summary>
        [Required]
        public string contentTitle { get; set; }

        /// <summary>
        /// Gets or sets the description of the content associated with the file.
        /// This provides additional context or information about the file.
        /// </summary>
        [Required]
        public string contentDescription { get; set; }

        /// <summary>
        /// Gets or sets the URL of an icon image representing the content.
        /// This could be used to display an icon or image for the file type (e.g., PDF, image).
        /// </summary>
        public string contentIconUrl { get; set; }

        /// <summary>
        /// A dictionary of additional properties associated with the file.
        /// This could include custom metadata or additional information that is not part of the main content.
        /// </summary>
        public Dictionary<string, string> additionalProperties { get; set; }
    }
}
