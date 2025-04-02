using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Src.ApplicationLaunchers.ServiceCollection;
using Src.Presentation.Commands;

namespace Src.Presentation.WebAPI.Endpoints.BankAccountEndpoints;

public class BankAccountAuthenticationEndpointAdder : IEndpointAdder
{
    public void AddEndpoint(WebApplication app, ServiceCollectionSettings settings)
    {
        app.MapGet("/bankAccount/authentication/{id:long}/{password}",
                async (long id, string password) =>
                {
                    AuthenticationBankAccountCommand curCommand =
                        ActivatorUtilities.CreateInstance<AuthenticationBankAccountCommand>(settings.Provider, id, password);

                    return await curCommand.Execute();
                })
            .WithDescription("Return BankAccount if same account exists, else null")
            .WithOpenApi();
    }
}
