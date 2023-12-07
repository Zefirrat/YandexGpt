using System.Threading;
using System.Threading.Tasks;

namespace Zefirrat.YandexGpt.Abstractions
{
    public interface IYaSummarizer
    {
        Task<string> SendAsync(string text, CancellationToken cancellationToken = default);
    }
}