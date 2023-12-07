using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Zefirrat.YandexGpt.Abstractions;
using Zefirrat.YandexGpt.Api.Client;
using Zefirrat.YandexGpt.Base;

namespace Zefirrat.YandexGpt.Summarizer
{
    public class YaSummarizer: YandexGptBase,IYaSummarizer
    {
        public YaSummarizer(IYaClient yaClient, IOptions<YandexGptOptions> options) : base(yaClient, options)
        {
        }

        protected override string Model => "summarization";
        public async Task<string> SendAsync(string text, CancellationToken cancellationToken = default)
        {
            return await SendBaseAsync(text, cancellationToken);
        }
    }
}