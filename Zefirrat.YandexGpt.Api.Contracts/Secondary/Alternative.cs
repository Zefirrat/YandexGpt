using System.Text.Json.Serialization;

namespace Zefirrat.YandexGpt.Api.Contracts.Secondary
{
    public class Alternative
    {
        [JsonPropertyName("message")] public Message Message { get; set; }

        [JsonPropertyName("status")] public string Status { get; set; }
    }
}