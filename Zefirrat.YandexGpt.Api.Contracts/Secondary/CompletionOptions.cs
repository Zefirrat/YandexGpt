using System.Text.Json.Serialization;

namespace Zefirrat.YandexGpt.Api.Contracts.Secondary
{
    public class CompletionOptions
    {
        [JsonPropertyName("stream")] public bool Stream { get; set; }

        [JsonPropertyName("temperature")] public double Temperature { get; set; }

        [JsonPropertyName("maxTokens")] public string MaxTokens { get; set; }

        [JsonIgnore]
        public static CompletionOptions Default =>
            new CompletionOptions() { Stream = false, Temperature = 0, MaxTokens = "1000" };
    }
}