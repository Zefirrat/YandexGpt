using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Zefirrat.YandexGpt.Abstractions;
using Zefirrat.YandexGpt.Api.Client;
using Zefirrat.YandexGpt.Api.Contracts.Secondary;
using Zefirrat.YandexGpt.Base;

namespace Zefirrat.YandexGpt.Chatter
{
    public class YaChatter : YandexGptBase, IYaChatter
    {
        public YaChatter(IYaClient yaClient, IOptions<YandexGptOptions> options) : base(yaClient, options)
        {
        }

        protected override string Model => "yandexgpt-lite";

        private List<Message> _messages = new List<Message>();

        public async Task<string> SendAsync(string message, CancellationToken cancellationToken = default)
        {
            var messages = _messages;
            messages.Add(Message.CreateMessage(message));
            var request = CreateRequest(messages);
            var response = await YaClient.SendAsync(request, cancellationToken);
            _messages = response.Result.Alternatives.Select(a => Message.CreateMessage(a.Message.Text, a.Message.Role))
                .ToList();
            return _messages.Last()
                .Text;
        }

        public Task<IList<(string Sender, string Message)>> GetHistoryAsync(
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IList<(string Sender, string Message)>>(_messages.Select(m => (m.Role, m.Text))
                .ToList());
        }

        public Task ClearHistoryAsync(CancellationToken cancellationToken = default)
        {
            _messages.Clear();
            return Task.CompletedTask;
        }
    }
}