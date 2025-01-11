using KoalaKit.DI;

namespace Koalakit.Orchestrations.Signals;

public interface ISignalSender : IKoalaScope
{
    Task Send(IKoalaSignal signal, CancellationToken cancellationToken = default);
}