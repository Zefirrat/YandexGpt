using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Zefirrat.YandexGpt.Api.Contracts.Secondary
{
    public class Result
    {
        [JsonPropertyName("alternatives")] public List<Alternative> Alternatives { get; set; }

        [JsonPropertyName("usage")] public Usage Usage { get; set; }

        [JsonPropertyName("modelVersion")] public string ModelVersion { get; set; }
    }
}