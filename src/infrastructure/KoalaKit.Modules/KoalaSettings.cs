namespace KoalaKit.Modules;

public sealed class KoalaSettings
{
    internal KoalaSettings() { }
    internal List<IKoalaModuleBase> Modules { get; } = [];
}