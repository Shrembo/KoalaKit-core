using Koalakit.Orchestrations.Operations;
using KoalaKit.DI;

namespace Koalakit.Orchestrations.Orchestrators;

public interface IOrchestrator : IKoalaScope
{
    Task<TResponse> Send<TResponse>(IKoalaOperation<TResponse> request, CancellationToken cancellationToken = default);
}