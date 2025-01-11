namespace Koalakit.Orchestrations.Signals;


public abstract class KoalaSignalHandlerWrapper
{
    public abstract Task Handle(IKoalaSignal signal, IServiceProvider serviceProvider, CancellationToken cancellationToken);
}