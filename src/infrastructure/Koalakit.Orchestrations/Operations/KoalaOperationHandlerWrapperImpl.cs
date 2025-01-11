using Koalakit.Orchestrations.Behaviors;
using KoalaKit.DI;
using KoalaKit.Primitives.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Koalakit.Orchestrations.Operations;

public sealed class KoalaOperationHandlerWrapperImpl<TOperation, TResponse>() : KoalaOperationHandlerWrapper<TResponse>, IKoalaScope
    where TOperation : IKoalaOperation<TResponse>
    where TResponse : KoalaResult
{
    public override Task<TResponse> Handle(
        IKoalaOperation<TResponse> request,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken)
    {

        Task<TResponse> Handler(CancellationToken t = default) => serviceProvider
            .GetRequiredService<IKoalaOperationHandler<TOperation, TResponse>>()
            .Handle((TOperation)request, t == default ? cancellationToken : t);

        return serviceProvider
            .GetServices<IKoalaBehavior<TOperation, TResponse>>()
            .Reverse()
            .Aggregate((RequestHandlerDelegate<TResponse>)Handler, (next, pipeline) => (t) => pipeline.Handle((TOperation)request, next, t == default ? cancellationToken : t))(cancellationToken);
    }
}