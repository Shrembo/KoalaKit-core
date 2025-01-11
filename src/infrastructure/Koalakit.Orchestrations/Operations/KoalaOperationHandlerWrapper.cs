namespace Koalakit.Orchestrations.Operations;

public abstract class KoalaOperationHandlerWrapper<TResponse>
{
    public abstract Task<TResponse> Handle(
        IKoalaOperation<TResponse> request,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken);
}