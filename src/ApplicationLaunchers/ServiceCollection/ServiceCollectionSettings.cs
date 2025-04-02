using Microsoft.Extensions.DependencyInjection;
using Src.Application.Extensions;
using Src.ApplicationLaunchers.ServiceCollection.Setups;
using Src.ApplicationLaunchers.ServiceCollection.Setups.Extensions;
using Src.Infrastructure.Extensions;

namespace Src.ApplicationLaunchers.ServiceCollection;

public class ServiceCollectionSettings
{
    public IServiceProvider Provider { get; private set; }

    private IServiceCollection Service { get; init; }

    public ServiceCollectionSettings()
    {
        Service = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

        Service.AddApplication()
               .AddInfrastructureDataAccess()
               .AddCommands();

        Provider = Service.BuildServiceProvider();
    }

    public void Setup(string appType)
    {
        switch (appType)
        {
            case "Web Application":
                Service.WebAppPostgresSetup();
                break;
            case "Console":
                Service.ConsolePostgresSetup();
                break;
            default:
                throw new ArgumentException("Wrong application type");
        }

        Provider = Service.BuildServiceProvider();
    }
}
