using Microsoft.Extensions.Hosting;

namespace KoalaKit.Modules;

public class KoalaModuleBase : IKoalaModuleBase
{
    public virtual void ConfigureApp(IHost host)
    {
    }

    public virtual void ConfigureKoala(KoalaContext koala)
    {
    }
}