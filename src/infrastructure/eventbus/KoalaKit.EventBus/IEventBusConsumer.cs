using KoalaKit.EventBus.Models;

namespace KoalaKit.EventBus;

public interface IEventBusConsumer<in TEto> where TEto : IKoalaEventMessage
{
    Task Consume(CancellationToken cancellationToken);
}