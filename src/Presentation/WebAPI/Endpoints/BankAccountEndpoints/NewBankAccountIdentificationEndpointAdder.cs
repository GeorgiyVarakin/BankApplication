using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Src.Application;
using Src.ApplicationLaunchers.ServiceCollection;
using Src.Presentation.Commands;

namespace Src.Presentation.WebAPI.Endpoints.BankAccountEndpoints;

public class NewBankAccountIdentificationEndpointAdder : IEndpointAdder
{
    public void AddEndpoint(WebApplication app, ServiceCollectionSettings settings)
    {
        app.MapPost("/bankAccount/identification/{password}",
                async (string password) =>
                {
                    IdentificationNewBankAccountCommand curCommand =
                        ActivatorUtilities.CreateInstance<IdentificationNewBankAccountCommand>(settings.Provider, password);

                    return await curCommand.Execute();
                })
            .WithDescription("Return null if password length is not between "
                             + ApplicationConstants.MinPasswordLength.ToString() + " and "
                             + ApplicationConstants.MaxPasswordLength.ToString()
                             + ", else return BankAccount")
            .WithOpenApi();
    }
}
