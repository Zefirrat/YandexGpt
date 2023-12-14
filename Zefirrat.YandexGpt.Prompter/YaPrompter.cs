using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Zefirrat.YandexGpt.Abstractions;
using Zefirrat.YandexGpt.Api.Client;
using Zefirrat.YandexGpt.Api.Contracts.Secondary;
using Zefirrat.YandexGpt.Base;

namespace Zefirrat.YandexGpt.Prompter
{
    public class YaPrompter : YandexGptBase, IYaPrompter
    {
        public YaPrompter(IYaClient yaClient, IOptions<YandexGptOptions> options) : base(yaClient, options)
        {
        }

        protected override string Model => "yandexgpt-lite";

        public async Task<string> SendAsync(string message, CancellationToken cancellationToken = default)
        {
            return await SendBaseAsync(message, cancellationToken);
        }

        public async Task<string> SendAsync(string message, int tokens, CancellationToken cancellationToken = new CancellationToken())
        {
            var request = CreateRequest(message);
            request.CompletionOptions.MaxTokens = tokens.ToString();
            return (await YaClient.SendAsync(request, cancellationToken)).Result.Alternatives[0].Message.Text;
            
        }
    }
}