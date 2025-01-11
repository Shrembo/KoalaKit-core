using KoalaKit.DI;
using Microsoft.Extensions.DependencyInjection;

namespace Koalakit.Orchestrations.Signals;

public sealed class KoalaSignalHandlerWrapperImpl<TSignal>
    : KoalaSignalHandlerWrapper, IKoalaScope where TSignal : IKoalaSignal
{
    public override async Task Handle(IKoalaSignal signal, IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var handlers = serviceProvider.GetServices<IKoalaSignalHandler<TSignal>>();
        foreach (var handler in handlers)
        {
            await handler.Handle((TSignal)signal, cancellationToken);
        }
    }
}