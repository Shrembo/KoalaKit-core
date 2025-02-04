namespace KoalaKit.EventBus.Models;

public sealed record EventBusConnectionDefinition
{
    public string Host { get; set; } = "127.0.0.1";
    public int Port { get; set; } = 5672;
    public string VirtualHost { get; set; } = "/";
    public string UserName { get; set; } = "guest";
    public string Password { get; set; } = "guest";
    public string Exchange { get; set; } = string.Empty;
}
