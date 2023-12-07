using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Zefirrat.YandexGpt.Abstractions;
using Zefirrat.YandexGpt.Api.Client;
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
    }
}