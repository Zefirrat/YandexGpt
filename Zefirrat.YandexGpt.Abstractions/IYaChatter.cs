using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Zefirrat.YandexGpt.Abstractions
{
    public interface IYaChatter
    {
        Task<string> SendAsync(string message, CancellationToken cancellationToken = default);

        Task<IList<(string Sender, string Message)>> GetHistoryAsync(CancellationToken cancellationToken = default);
        
        Task ClearHistoryAsync(CancellationToken cancellationToken = default);
    }
}