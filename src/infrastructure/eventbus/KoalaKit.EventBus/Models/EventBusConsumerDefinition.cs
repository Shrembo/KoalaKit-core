namespace KoalaKit.EventBus.Models;

public sealed record EventBusConsumerDefinition
{
    public EventBusConsumerDefinition() { }

    public EventBusConsumerDefinition(bool active)
    {
        Active = active;
    }

    public bool Active { get; set; }
    public string[] Channels { get; set; } = [];
}
