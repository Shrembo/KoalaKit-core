namespace Koalakit.Orchestrations.Signals;

public interface IKoalaSignalHandler<TSignal> where TSignal : IKoalaSignal
{
    Task Handle(TSignal signal, CancellationToken cancellationToken);
}