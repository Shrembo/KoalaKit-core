using Microsoft.Extensions.Hosting;

namespace KoalaKit.Modules;

public static class HostExtensions
{
    public static IHost UseKoalaModules(this IHost host, KoalaContext koala)
    {
        foreach (var module in koala.Settings.Modules)
        {
            module.ConfigureApp(host);
        }
        return host;
    }
}