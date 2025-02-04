using KoalaKit.EventBus.Models;

namespace KoalaKit.EventBus.Services;

public interface IEventBusQueueFactory<in TEto> where TEto : IKoalaEventMessage
{
    IEnumerable<EventBusQueueDefinition> Create();
    EventBusQueueDefinition Create(TEto eto);
}