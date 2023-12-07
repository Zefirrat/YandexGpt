using System.Text.Json.Serialization;

namespace Zefirrat.YandexGpt.Api.Contracts.Secondary
{
    public class Usage
    {
        [JsonPropertyName("inputTextTokens")] public string InputTextTokens { get; set; }

        [JsonPropertyName("completionTokens")] public string CompletionTokens { get; set; }

        [JsonPropertyName("totalTokens")] public string TotalTokens { get; set; }
    }
}