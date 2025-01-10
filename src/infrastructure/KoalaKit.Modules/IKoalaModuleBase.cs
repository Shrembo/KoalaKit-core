using Microsoft.Extensions.Hosting;

namespace KoalaKit.Modules;

public interface IKoalaModuleBase
{
    void ConfigureApp(IHost host);
    void ConfigureKoala(KoalaContext koala);
}