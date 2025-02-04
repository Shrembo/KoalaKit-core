namespace KoalaKit.EventBus.Models;

public sealed record EventBusSettings
{
    public Dictionary<string, EventBusConnectionDefinition> Connections { get; set; } = [];
    public Dictionary<string, EventBusConsumerDefinition> Consumers { get; set; } = [];
}