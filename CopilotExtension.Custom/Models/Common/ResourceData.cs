namespace CopilotExtension.Custom.Models.Common
{
    public class ResourceData
    {
        /// <summary>
        /// This input provides all the content from the email thread in text format.
        /// </summary>
        public string plaintextBody { get; set; }

        /// <summary>
        /// This input provides all the content from the email thread in HTML format.
        /// </summary>
        public string fullHtmlBody { get; set; }

        /// <summary>
        /// This input provides the subject of the email.
        /// </summary>
        public string subject { get; set; }

        /// <summary>
        /// This input provides the sender's email address.
        /// </summary>
        public string from { get; set; }

        /// <summary>
        /// This input provides the receiver's email address.
        /// </summary>
        public List<string> to { get; set; }

        /// <summary>
        /// This input provides all the receiver's email addresses that are included in the Cc field of the email.
        /// </summary>
        public List<string> cc { get; set; }

        /// <summary>
        /// This input provides all the receiver's email addresses that are added in the Bcc field of the email.
        /// </summary>
        public List<string> bcc { get; set; }

        /// <summary>
        /// This input provides the timestamp of the email.
        /// </summary>
        public DateTimeOffset sentDateTime { get; set; }

        /// <summary>
        /// This input provides the message ID of the email.
        /// </summary>
        public string messageId { get; set; }

        /// <summary>
        /// This input provides the conversation ID of the email thread.
        /// </summary>
        public string conversationId { get; set; }
    }

}
