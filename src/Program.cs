using Microsoft.Extensions.DependencyInjection;
using Src.ApplicationLaunchers;
using Src.ApplicationLaunchers.ServiceCollection;
using Src.Infrastructure.DatabaseManager;

namespace Src;

public class Program
{
    public static async Task Main()
    {
        var settings = new ServiceCollectionSettings();
        IServiceProvider provider = settings.Provider;

        var page = new ApplicationChoosePage();
        string choice = page.Execute();

        settings.Setup(choice);
        provider = settings.Provider;

        IDatabaseManager databaseManager = settings.Provider.GetRequiredService<IDatabaseManager>();
        await databaseManager.DatabaseSetup();

        IApplicationLauncher launcher = provider.GetRequiredService<IApplicationLauncher>();
        await launcher.Launch(settings);
    }
}
