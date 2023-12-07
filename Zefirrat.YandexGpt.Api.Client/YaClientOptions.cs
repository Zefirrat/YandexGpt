namespace Zefirrat.YandexGpt.Api.Client
{
    /// <summary>
    /// Auth and other options for requests to yandex cloud
    /// </summary>
    public class YaClientOptions
    {
        /// <summary>
        /// Default "Bearer" for IAM-token or "Api-Key" for Service account
        /// </summary>
        public string AuthenticationScheme { get; set; }
        
        /// <summary>
        /// IAM-token or API-key
        /// see https://cloud.yandex.ru/docs/iam/concepts/authorization/iam-token
        /// see https://cloud.yandex.ru/docs/iam/concepts/authorization/api-key
        /// </summary>
        public string Token                { get; set; }
        
        /// <summary>
        /// ID of catalog with trained model
        /// see https://cloud.yandex.ru/docs/resource-manager/operations/folder/get-id
        /// </summary>
        public string CatalogId            { get; set; }

        public class OverridesModel
        {
            public string? LlmBaseUrl       { get; set; }
            public string? OperationBaseUrl { get; set; }
            public string? Completion       { get; set; }
            public string? CompletionAsync  { get; set; }
        }

        public OverridesModel? Overrides { get; set; }
    }
}