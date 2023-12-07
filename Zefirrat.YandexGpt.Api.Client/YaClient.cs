using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Zefirrat.YandexGpt.Api.Contracts;

namespace Zefirrat.YandexGpt.Api.Client
{
    public class YaClient : IYaClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<YaClientOptions> _options;

        private string LlmBaseUrl =>
            string.IsNullOrEmpty(_options.Value.Overrides.LlmBaseUrl)
                ? "https://llm.api.cloud.yandex.net/foundationModels/v1/"
                : _options.Value.Overrides.LlmBaseUrl;

        private string OperationBaseUrl =>
            string.IsNullOrEmpty(_options.Value.Overrides.OperationBaseUrl)
                ? "https://operation.api.cloud.yandex.net/operations/"
                : _options.Value.Overrides.OperationBaseUrl;

        private string Completion =>
            string.IsNullOrEmpty(_options.Value.Overrides.Completion)
                ? "completion"
                : _options.Value.Overrides.Completion;

        private string CompletionAsync =>
            string.IsNullOrEmpty(_options.Value.Overrides.CompletionAsync)
                ? "completionAsync"
                : _options.Value.Overrides.CompletionAsync;

        private string Authorization => _options.Value.AuthenticationScheme;
        private string Token         => _options.Value.Token;
        private string CatalogId     => _options.Value.CatalogId;

        public YaClient([NotNull] IHttpClientFactory httpClientFactory, [NotNull] IOptions<YaClientOptions> options)
        {
            _httpClient = httpClientFactory.CreateClient(nameof(YaClient));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public YaClient([NotNull] IHttpClientFactory httpClient, [NotNull] YaClientOptions options) : this(httpClient,
            new OptionsWrapper<YaClientOptions>(options))
        {
        }

        public async Task<Response> SendAsync(Request request, CancellationToken cancellationToken = default)
        {
            var method = LlmBaseUrl + Completion;
            using var responseMessage =
                await _httpClient.SendAsync(CreateRequestMessage(request, method), cancellationToken);
            var response = await GetBody<Response>(responseMessage);
            return response;
        }


        public async Task<DetachedOperation> SendDetachedAsync(
            Request request,
            CancellationToken cancellationToken = default)
        {
            var method = LlmBaseUrl + CompletionAsync;
            using var responseMessage =
                await _httpClient.SendAsync(CreateRequestMessage(request, method), cancellationToken);
            var response = await GetBody<DetachedOperation>(responseMessage);
            return response;
        }

        public async Task<OperationInfo> GetOperationAsync(
            string operationId,
            CancellationToken cancellationToken = default)
        {
            var method = OperationBaseUrl + operationId;
            using var responseMessage =
                await _httpClient.SendAsync(CreateRequestMessage(null, method), cancellationToken);
            var response = await GetBody<OperationInfo>(responseMessage);
            return response;
        }

        private HttpRequestMessage CreateRequestMessage(Request? request, string url)
        {
            var requestMessage = new HttpRequestMessage();
            if (request is { }) requestMessage.Content = JsonContent.Create(request);

            requestMessage.RequestUri = new Uri(url);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(Authorization, Token);
            requestMessage.Headers.Add("x-folder-id", CatalogId);
            return requestMessage;
        }

        private static async Task<T> GetBody<T>(HttpResponseMessage responseMessage)
        {
            var response = JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
            return response;
        }
    }
}