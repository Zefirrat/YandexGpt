using System.Text.Json.Serialization;
using Zefirrat.YandexGpt.Api.Contracts.Secondary;

namespace Zefirrat.YandexGpt.Api.Contracts
{
    public class Response
    {
        [JsonPropertyName("result")] public Result Result { get; set; }
    }
}