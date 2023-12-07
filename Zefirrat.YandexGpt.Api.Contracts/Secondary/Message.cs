using System.Text.Json.Serialization;

namespace Zefirrat.YandexGpt.Api.Contracts.Secondary
{
    public class Message
    {
        [JsonPropertyName("role")] public string Role { get; set; }

        [JsonPropertyName("text")] public string Text { get; set; }

        public static Message CreateMessage(string text, string role = DefaultRoles.User)
        {
            return new Message() { Role = role, Text = text };
        }
        
        public static class DefaultRoles
        {
            public const string User = "user";
            public const string Assistant = "assistant";
            public const string System = "system";
        }
    }
}