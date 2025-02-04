using KoalaKit.EventBus.Models;
using Microsoft.Extensions.Options;

namespace KoalaKit.EventBus.Services;

public sealed class EventBusConfigurationSelector<TEto> : IEventBusConfigurationSelector<TEto> where TEto : IKoalaEventMessage
{
    private const string defaultConnectionName = "default";
    private readonly EventBusSettings _settings;

    public EventBusConfigurationSelector(IOptions<EventBusSettings> options)
    {
        _settings = options.Value;

        if (_settings?.Connections is null || !_settings.Connections.ContainsKey(defaultConnectionName))
            throw new ArgumentException("Event Bus Queus configuration must contains at least `default` connection!");
    }

    public EventBusConnectionDefinition Select()
    {
        return _settings.Connections[defaultConnectionName];
    }

    public EventBusConnectionDefinition Select(string identifier)
    {
        if (_settings.Connections.TryGetValue(identifier, out EventBusConnectionDefinition? value))
            return value;

        return _settings.Connections[defaultConnectionName];
    }

    public EventBusConsumerDefinition? SelectConsumer(string identifier)
    {
        if (string.IsNullOrEmpty(identifier)) return default;

        if (_settings.Consumers.TryGetValue(identifier, out var consumer))
        {
            return consumer;
        }
        return new EventBusConsumerDefinition(true);/*consume is running by default*/
    }
}
