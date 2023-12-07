using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Zefirrat.YandexGpt.Api.Client;
using Zefirrat.YandexGpt.Api.Contracts;
using Zefirrat.YandexGpt.Api.Contracts.Secondary;

namespace Zefirrat.YandexGpt.Base
{
    /// <summary>
    /// Base class for default and custom implementations
    /// </summary>
    public abstract class YandexGptBase
    {
        private readonly IOptions<YandexGptOptions> _options;
        private string ModelBaseUrl => $"gpt://{CatalogId}/";

        protected readonly IYaClient YaClient;

        /// <summary>
        /// Description same as <see cref="YaClientOptions.CatalogId"/>
        /// </summary>
        protected string CatalogId => _options.Value.Client.CatalogId;

        /// <summary>
        /// For the value use for default models: yandex-gpt-light or summarization
        /// Or the custom models see https://cloud.yandex.ru/docs/datasphere/concepts/models/tuned-models
        /// </summary>
        protected abstract string Model { get; }

        public YandexGptBase([NotNull] IYaClient yaClient, [NotNull] IOptions<YandexGptOptions> options)
        {
            YaClient = yaClient ?? throw new ArgumentNullException(nameof(yaClient));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }


        protected Request CreateRequest(string text)
        {
            return CreateRequest(new List<Message>() { Message.CreateMessage(text) });
        }

        protected Request CreateRequest(IEnumerable<Message> messages)
        {
            return CreateRequest(Model, messages, CompletionOptions.Default);
        }

        protected Request CreateRequest(string model, IEnumerable<Message> messages)
        {
            return CreateRequest(model, messages, CompletionOptions.Default);
        }

        protected Request CreateRequest(
            string model,
            IEnumerable<Message> messages,
            CompletionOptions completionOptions)
        {
            return new Request()
            {
                ModelUri = ModelBaseUrl + model,
                CompletionOptions = completionOptions,
                Messages = messages.ToList(),
            };
        }

        /// <summary>
        /// Simplest communication: text in, text out.
        /// </summary>
        /// <param name="text">Your text/message to gpt</param>
        /// <returns>Response of gpt</returns>
        protected async Task<string> SendBaseAsync(string text, CancellationToken cancellationToken = default)
        {
            var request = CreateRequest(text);
            var response = await YaClient.SendAsync(request, cancellationToken);
            var responseMessage = response.Result.Alternatives.Last()
                .Message.Text;
            return responseMessage;
        }
    }
}