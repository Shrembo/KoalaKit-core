using KoalaKit.DI;

namespace Koalakit.Orchestrations.Operations;

public interface IKoalaOperationHandler
{
}

public interface IKoalaOperationHandler<TOperation, TResponse> : IKoalaOperationHandler, IKoalaScope where TOperation : IKoalaOperation<TResponse>
{
    Task<TResponse> Handle(TOperation request, CancellationToken cancellationToken);
}