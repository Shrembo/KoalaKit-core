using Koalakit.Orchestrations.Operations;
using Koalakit.Orchestrations.Signals;
using Microsoft.Extensions.DependencyInjection;

namespace Koalakit.Orchestrations.Orchestrators;

internal sealed class Orchestrator(IServiceProvider serviceProvider, ISignalSender signalSender) : IOrchestrator
{
    readonly IServiceProvider _serviceProvider = serviceProvider;
    readonly ISignalSender _signalSender = signalSender;
    public async Task<TResponse> Send<TResponse>(IKoalaOperation<TResponse> operation, CancellationToken cancellationToken = default)
    {
        var wrapperType = typeof(KoalaOperationHandlerWrapperImpl<,>).MakeGenericType(operation.GetType(), typeof(TResponse));
        var wrapper = (KoalaOperationHandlerWrapper<TResponse>)_serviceProvider.GetRequiredService(wrapperType);

        //var handlerType = typeof(IKoalaOperationHandler<,>).MakeGenericType(operation.GetType(), typeof(TResponse));
        //var handler = _serviceProvider.GetRequiredService(handlerType);
        // if (handler is IKoalaOperationHandler baseHandler)
        // {
            // This is a hack to allow the handler to access the current scope
        // }

        var result = await wrapper.Handle(operation, _serviceProvider, cancellationToken);
        await _signalSender.Send(new OperationCompletedSignal(), cancellationToken);
        return result;
    }
}