using Koalakit.Orchestrations.Behaviors;
using KoalaKit.DI;
using KoalaKit.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Koalakit.Orchestrations;

public class OrchestrationModule : KoalaModuleBase
{
    public override void ConfigureKoala(KoalaContext koala)
    {
        koala.RegisterAllServices(typeof(OrchestrationModule).Assembly);
        koala.Services.AddScoped(typeof(IKoalaBehavior<,>), typeof(LoggingBehavior<,>));
        koala.Services.AddScoped(typeof(IKoalaBehavior<,>), typeof(ValidationBehavior<,>));

        base.ConfigureKoala(koala);
    }
}