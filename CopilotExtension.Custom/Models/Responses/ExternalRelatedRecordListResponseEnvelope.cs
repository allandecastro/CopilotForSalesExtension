using System.Text.Json.Serialization;

namespace CopilotExtension.Custom.Models.Responses
{
    public class ExternalRelatedRecordListResponseEnvelope
    {
        [JsonPropertyName("value")]
        public List<ExternalRelatedRecord> value { get; set; } = new();

        [JsonPropertyName("hasMoreResults")]
        public bool hasMoreResults { get; set; }
    }

    public class ExternalRelatedRecord
    {
        [JsonPropertyName("recordId")]
        public string recordId { get; set; }

        [JsonPropertyName("recordTitle")]
        public string recordTitle { get; set; }

        [JsonPropertyName("recordType")]
        public string recordType { get; set; }

        [JsonPropertyName("recordTypeDisplayName")]
        public string recordTypeDisplayName { get; set; }

        [JsonPropertyName("recordTypePluralDisplayName")]
        public string recordTypePluralDisplayName { get; set; }

        [JsonPropertyName("url")]
        public string? url { get; set; }

        [JsonPropertyName("additionalProperties")]
        public Dictionary<string, string>? additionalProperties { get; set; }
    }
}
