namespace Koalakit.Orchestrations.Operations;

public abstract class KoalaBaseHandler<TOperation, TResponse> : IKoalaOperationHandler<TOperation, TResponse>
    where TOperation : IKoalaOperation<TResponse>
{
    public abstract Task<TResponse> Handle(TOperation request, CancellationToken cancellationToken);
}