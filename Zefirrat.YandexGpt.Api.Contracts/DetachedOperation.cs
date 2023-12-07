using System;
using System.Text.Json.Serialization;

namespace Zefirrat.YandexGpt.Api.Contracts
{
    public class DetachedOperation
    {
        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }

        [JsonPropertyName("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonPropertyName("createdBy")] public string CreatedBy { get; set; }

        [JsonPropertyName("modifiedAt")] public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("done")] public bool Done { get; set; }

        [JsonPropertyName("metadata")] public object Metadata { get; set; }
    }
}