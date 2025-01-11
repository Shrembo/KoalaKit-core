using KoalaKit.Primitives.Results;

namespace Koalakit.Orchestrations.Behaviors;

public interface IKoalaBehavior<in TOperation, TResponse>
    where TOperation : notnull
    where TResponse : KoalaResult
{
    Task<TResponse> Handle(TOperation request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);
}

public delegate Task<TResponse> RequestHandlerDelegate<TResponse>(CancellationToken cancellationToken = default);