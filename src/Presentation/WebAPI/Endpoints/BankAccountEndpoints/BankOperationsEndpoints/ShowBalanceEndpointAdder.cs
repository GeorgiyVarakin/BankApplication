using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Src.ApplicationLaunchers.ServiceCollection;
using Src.Presentation.Commands.BankAccountCommands;

namespace Src.Presentation.WebAPI.Endpoints.BankAccountEndpoints.BankOperationsEndpoints;

public class ShowBalanceEndpointAdder : IEndpointAdder
{
    public void AddEndpoint(WebApplication app, ServiceCollectionSettings settings)
    {
        app.MapGet("/bankAccount/showBalance/{id:long}",
                async (long id) =>
                {
                    ShowBalanceCommand curCommand =
                        ActivatorUtilities.CreateInstance<ShowBalanceCommand>(settings.Provider, id);

                    return await curCommand.Execute();
                })
            .WithDescription("Return long integer or null if account doesn't exists")
            .WithOpenApi();
    }
}
