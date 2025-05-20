using System.Text.Json.Serialization;

namespace CopilotExtension.Custom.Models.Responses
{
    public class ActivityListResponseEnvelope
    {
        [JsonPropertyName("value")]
        public List<ActivityItem> value { get; set; } = new();

        [JsonPropertyName("hasMoreResults")]
        public bool hasMoreResults { get; set; }
    }

    public class ActivityItem
    {
        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("dateTime")]
        public string dateTime { get; set; }

        [JsonPropertyName("url")]
        public string? url { get; set; }

        [JsonPropertyName("additionalProperties")]
        public Dictionary<string, string>? additionalProperties { get; set; }
    }
}
