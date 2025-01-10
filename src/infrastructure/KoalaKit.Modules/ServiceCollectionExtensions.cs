using KoalaKit.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;

namespace KoalaKit.Modules;

public static class ServiceCollectionExtensions
{
    public static KoalaContext BuildKoalaModule(this IServiceCollection services, Action<KoalaContext> configure)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile($"appsettings.{new HostingEnvironment().EnvironmentName}.json", optional: true, reloadOnChange: true)
            .Build();

        return services.AddKoala(configuration, configure);
    }

    public static KoalaContext AddKoala(this IServiceCollection services, IConfiguration configuration, Action<KoalaContext> configure)
    {
        var koala = new KoalaContext(services, configuration);

        configure.Invoke(koala);

        services.AddSingleton(koala.Settings);
        return koala;
    }
}