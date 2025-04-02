using Microsoft.Extensions.DependencyInjection;
using Src.ApplicationLaunchers.Console;
using Src.ApplicationLaunchers.Console.Extensions;

namespace Src.ApplicationLaunchers.ServiceCollection.Setups;

public static class ConsoleSetups
{
    public static void ConsolePostgresSetup(this IServiceCollection collection)
    {
        collection.AddSingleton<IApplicationLauncher, ConsoleApplicationLauncher>();

        collection.AddConsolePages();
    }
}
