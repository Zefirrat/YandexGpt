using System.Threading;
using System.Threading.Tasks;
using Zefirrat.YandexGpt.Api.Contracts;

namespace Zefirrat.YandexGpt.Api.Client
{
    public interface IYaClient
    {
        Task<Response> SendAsync(Request request, CancellationToken cancellationToken = default);
        Task<DetachedOperation> SendDetachedAsync(Request request, CancellationToken cancellationToken = default);
        Task<OperationInfo> GetOperationAsync(string operationId, CancellationToken cancellationToken = default);
    }
}