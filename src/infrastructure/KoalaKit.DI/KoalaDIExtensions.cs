using System.Reflection;
using KoalaKit.Modules;
using KoalaKit.Primitives.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace KoalaKit.DI;

public static class KoalaDIExtensions
{
    public static void RegisterAllServices(this KoalaContext koala, Assembly assembly)
    {
        RegisterSingletonServices(koala, assembly);
        RegisterScopedServices(koala, assembly);
        RegisterTransientServices(koala, assembly);
    }

    public static void RegisterSingletonServices(KoalaContext koala, Assembly assembly)
    {
        var singletonTypes = assembly.GetTypes()
            .Where(type => !type.IsInterface && !type.IsAbstract)
            .Where(type => type.GetInterfaces().Any(inter => inter == typeof(IKoalaSingleton)));

        foreach (var singletonType in singletonTypes)
        {
            var interfaces = singletonType.GetInterfaces();
            if (interfaces.HasItems())
            {
                koala.Services.AddSingleton(interfaces.First(), singletonType);
            }
        }
    }

    public static void RegisterScopedServices(KoalaContext koala, Assembly assembly)
    {
        var scopedTypes = assembly.GetTypes()
            .Where(type => !type.IsInterface && !type.IsAbstract)
            .Where(type => type.GetInterfaces().Any(inter => inter == typeof(IKoalaScope)));

        foreach (var scopedType in scopedTypes)
        {
            var interfaces = scopedType.GetInterfaces().Where(inter => inter != typeof(IKoalaScope)).ToList();
            if (interfaces.HasItems())
            {
                foreach (var inter in interfaces)
                {
                    koala.Services.AddScoped(inter, scopedType);
                }
            }
            else
            {
                koala.Services.AddScoped(scopedType);
            }
        }
    }

    public static void RegisterTransientServices(KoalaContext koala, Assembly assembly)
    {
        var transientTypes = assembly.GetTypes()
            .Where(type => !type.IsInterface && !type.IsAbstract)
            .Where(type => type.GetInterfaces().Any(inter => inter == typeof(IKoalaTransient)));

        foreach (var transientType in transientTypes)
        {
            var interfaces = transientType.GetInterfaces();
            if (interfaces.HasItems())
            {
                koala.Services.AddTransient(interfaces.First(), transientType);
            }
        }
    }

    public static bool IsSubclassOfRawGeneric(Type generic, Type? toCheck)
    {
        while (toCheck != null && toCheck != typeof(object))
        {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur)
            {
                return true;
            }
            toCheck = toCheck.BaseType;
        }
        return false;
    }



    public static void Replace<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        var descriptor = services.FirstOrDefault(service => service.ServiceType == typeof(TService));
        if (descriptor is not null)
        {
            services.Remove(descriptor);
        }
        services.AddTransient<TService, TImplementation>();
    }
}