using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KoalaKit.Modules;

public sealed class KoalaContext(IServiceCollection services, IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;
    public KoalaSettings Settings { get; set; } = new KoalaSettings();
    public IServiceCollection Services { get; } = services;

    public void AddModule(IKoalaModuleBase module)
    {
        Settings.Modules.Add(module);
    }

    public IReadOnlyList<IKoalaModuleBase> GetModules() => Settings.Modules.AsReadOnly();
}