using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Src.ApplicationLaunchers.ServiceCollection;
using Src.Presentation.Commands.BankAccountCommands;

namespace Src.Presentation.WebAPI.Endpoints.BankAccountEndpoints.BankOperationsEndpoints;

public class ShowAccountHistoryEndpointAdder : IEndpointAdder
{
    public void AddEndpoint(WebApplication app, ServiceCollectionSettings settings)
    {
        app.MapGet("/bankAccount/showHistory/{id:long}",
                async (long id) =>
                {
                    ShowAccountHistoryCommand curCommand =
                        ActivatorUtilities.CreateInstance<ShowAccountHistoryCommand>(settings.Provider, id);

                    return await curCommand.Execute();
                })
            .WithDescription("Return list of logs")
            .WithOpenApi();
    }
}
