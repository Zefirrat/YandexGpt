using System.Threading;
using System.Threading.Tasks;

namespace Zefirrat.YandexGpt.Abstractions
{
    public interface IYaPrompter
    {
        Task<string> SendAsync(string message, CancellationToken cancellationToken = default);
        Task<string> SendAsync(string message, int tokens, CancellationToken cancellationToken = default);
    }
}