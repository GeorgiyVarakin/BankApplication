using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Src.ApplicationLaunchers.ServiceCollection;
using Src.Presentation.Commands.BankAccountCommands;

namespace Src.Presentation.WebAPI.Endpoints.BankAccountEndpoints.BankOperationsEndpoints;

public class WithdrawMoneyOperationEndpointAdder : IEndpointAdder
{
    public void AddEndpoint(WebApplication app, ServiceCollectionSettings settings)
    {
        app.MapPost("/bankAccount/withdrawMoney/{id:long}/{delta:long}",
                async (long id, long delta) =>
                {
                    WithdrawMoneyCommand curCommand =
                        ActivatorUtilities.CreateInstance<WithdrawMoneyCommand>(settings.Provider, id, delta);

                    return await curCommand.Execute();
                })
            .WithDescription("Return BankOperationAnswer")
            .WithOpenApi();
    }
}
