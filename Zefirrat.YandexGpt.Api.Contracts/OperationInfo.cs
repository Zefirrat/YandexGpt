using System;
using System.Text.Json.Serialization;

namespace Zefirrat.YandexGpt.Api.Contracts
{
    public class OperationInfo
    {
        [JsonPropertyName("done")] public bool Done { get; set; }

        [JsonPropertyName("response")] public Response Response { get; set; }

        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonPropertyName("createdBy")] public string CreatedBy { get; set; }

        [JsonPropertyName("modifiedAt")] public DateTime ModifiedAt { get; set; }
    }
}