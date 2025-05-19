using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CopilotExtension.Custom.Models.Common
{
    public class ExtensibilityEmailData
    {
        [Required]
        [JsonPropertyName("plaintextBody")]
        public string plaintextBody { get; set; }

        [JsonPropertyName("fullHtmlBody")]
        public string fullHtmlBody { get; set; }

        [JsonPropertyName("subject")]
        public string subject { get; set; }

        [JsonPropertyName("from")]
        public string from { get; set; }

        [JsonPropertyName("to")]
        public List<string> to { get; set; }

        [JsonPropertyName("cc")]
        public List<string> cc { get; set; }

        [JsonPropertyName("bcc")]
        public List<string> bcc { get; set; }

        [JsonPropertyName("sentDateTime")]
        public DateTime sentDateTime { get; set; }

        [JsonPropertyName("messageId")]
        public string messageId { get; set; }

        [JsonPropertyName("conversationId")]
        public string conversationId { get; set; }
    }
}