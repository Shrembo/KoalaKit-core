namespace KoalaKit.EventBus.Models;

public readonly struct EventBusQueueDefinition(string name, string route, EventBusConnectionDefinition connection)
{
    public string Name { get; } = name.ToLower();
    public string Route { get; } = route.ToLower();
    public EventBusConnectionDefinition Connection { get; } = connection;
}
