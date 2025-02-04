using KoalaKit.DI;
using KoalaKit.EventBus.Models;

namespace KoalaKit.EventBus;

public interface IEventBusPublisher<in TEto> : IKoalaTransient
    where TEto : IKoalaEventMessage
{
    Task Publish(TEto eto, CancellationToken cancellationToken = default);
}


public interface IEventBusPublisher : IKoalaTransient
{
    Task Publish<TEto>(TEto eto, CancellationToken cancellationToken = default) where TEto : IKoalaEventMessage;
}