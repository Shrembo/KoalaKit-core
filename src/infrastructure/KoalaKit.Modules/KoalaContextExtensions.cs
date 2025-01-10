using System.Reflection;

namespace KoalaKit.Modules;

public static class KoalaContextExtensions
{
    public static KoalaContext AddModules(this KoalaContext koala, Type type)
    {
        var instance = (IKoalaModuleBase?)Activator.CreateInstance(type, null);

        if (instance == null)
        {
            return koala;
        }

        instance.ConfigureKoala(koala);
        koala.Settings.Modules.Add(instance);
        return koala;
    }

    public static KoalaContext AddModules(this KoalaContext koala, IEnumerable<Type> types)
    {
        if (types is not null)
        {
            var instances = types
                .Select(module => (IKoalaModuleBase?)Activator.CreateInstance(module, null))
                .Where(instance => instance != null);

            foreach (var instance in instances)
            {
                if (instance == null) continue;
                instance.ConfigureKoala(koala);
                koala.Settings.Modules.Add(instance);
            }
        }
        return koala;
    }

    public static KoalaContext AddModules(this KoalaContext koala, IEnumerable<Assembly> assemblies)
    {
        var modulesQuery = from assembly in assemblies
                           from type in assembly.GetExportedTypes()
                           where type.IsClass && !type.IsAbstract && typeof(IKoalaModuleBase).IsAssignableFrom(type)
                           select type;


        var modules = modulesQuery.ToList();

        var instances = modules
            .Select(module => (IKoalaModuleBase?)Activator.CreateInstance(module, null))
            .Where(instance => instance != null);

        foreach (var instance in instances)
        {
            if (instance == null) continue;
            instance.ConfigureKoala(koala);
            koala.Settings.Modules.Add(instance);
        }

        return koala;
    }
}