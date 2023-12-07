using System.Collections.Generic;
using System.Text.Json.Serialization;
using Zefirrat.YandexGpt.Api.Contracts.Secondary;

namespace Zefirrat.YandexGpt.Api.Contracts
{
    public class Request
    {
        [JsonPropertyName("modelUri")]
        public string ModelUri { get; set; }

        [JsonPropertyName("completionOptions")]
        public CompletionOptions CompletionOptions { get; set; }

        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; }
    }

}