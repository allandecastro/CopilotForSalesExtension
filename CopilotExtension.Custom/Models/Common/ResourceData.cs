namespace CopilotExtension.Custom.Models.Common
{
    public class ResourceData
    {
        /// <summary>
        /// The complete email body includes all the previous messages of the email thread in it.
        /// </summary>
        public string plaintextBody { get; set; }

        /// <summary>
        /// The full HTML version of the email body that includes all the previous messages of the email thread in it.
        /// </summary>
        public string fullHtmlBody { get; set; }

        /// <summary>
        /// Subject of the email.
        /// </summary>
        public string subject { get; set; }

        /// <summary>
        /// Sender's email address.
        /// </summary>
        public string from { get; set; }

        /// <summary>
        /// Receiver's email addresses.
        /// </summary>
        public List<string> to { get; set; }

        /// <summary>
        /// Receiver's email addresses added in the Cc field of the email.
        /// </summary>
        public List<string> cc { get; set; }

        /// <summary>
        /// Receiver's email addresses added in the Bcc field of the email.
        /// </summary>
        public List<string> bcc { get; set; }

        /// <summary>
        /// The date and time of the email in UTC format along with the Offset property.
        /// </summary>
        public DateTimeOffset sentDateTime { get; set; }

        /// <summary>
        /// The Graph message Id of the email.
        /// </summary>
        public string messageId { get; set; }

        /// <summary>
        /// The Graph conversation Id of the email thread.
        /// </summary>
        public string conversationId { get; set; }
    }

}
