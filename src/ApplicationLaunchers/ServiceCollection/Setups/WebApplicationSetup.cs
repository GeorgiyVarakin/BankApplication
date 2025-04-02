using Microsoft.Extensions.DependencyInjection;
using Src.Presentation.WebAPI;

namespace Src.ApplicationLaunchers.ServiceCollection.Setups;

public static class WebApplicationSetup
{
    public static void WebAppPostgresSetup(this IServiceCollection collection)
    {
        collection.AddSingleton<IApplicationLauncher, WebApplicationLauncher>();
    }
}
