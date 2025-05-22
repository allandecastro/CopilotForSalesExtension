using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CopilotExtension.Custom.Models.Requests
{
    public class EmailInsightsRequest
    {
        [Required(ErrorMessage = "Resource data is required.")]
        [JsonPropertyName("resourceData")]
        public ExtensibilityEmailData resourceData { get; set; }

        [JsonPropertyName("relatedEntities")]
        public List<RelatedEntity> relatedEntities { get; set; }

        [JsonPropertyName("crmType")]
        public string crmType { get; set; }

        [Url(ErrorMessage = "Invalid CRM Org URL format.")]
        [JsonPropertyName("crmOrgUrl")]
        public string crmOrgUrl { get; set; }

        [Range(1, 1000, ErrorMessage = "Top value must be between 1 and 1000.")]
        [JsonPropertyName("top")]
        public int? top { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Skip value must be a non-negative number.")]
        [JsonPropertyName("skip")]
        public int? skip { get; set; }
    }

    public class RelatedEntity
    {
        [Required(ErrorMessage = "Entity ID is required.")]
        [JsonPropertyName("entityId")]
        public string entityId { get; set; }

        [Required(ErrorMessage = "Entity type is required.")]
        [JsonPropertyName("entityType")]
        public string entityType { get; set; }

        [JsonPropertyName("entitySource")]
        public string entitySource { get; set; }
    }

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