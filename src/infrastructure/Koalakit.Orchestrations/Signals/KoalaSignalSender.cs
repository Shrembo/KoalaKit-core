using Microsoft.Extensions.DependencyInjection;

namespace Koalakit.Orchestrations.Signals;

internal sealed class KoalaSignalSender(IServiceProvider serviceProvider) : ISignalSender
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task Send(IKoalaSignal signal, CancellationToken cancellationToken = default)
    {
        var wrapperType = typeof(KoalaSignalHandlerWrapperImpl<>).MakeGenericType(signal.GetType());
        var wrapper = (KoalaSignalHandlerWrapper)_serviceProvider.GetRequiredService(wrapperType);
        await wrapper.Handle(signal, _serviceProvider, cancellationToken);
    }
}