using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Src.Application.ResultType;
using Src.ApplicationLaunchers.ServiceCollection;
using Src.Presentation.Commands;

namespace Src.Presentation.WebAPI.Endpoints.AdminEndpoints;

public class AdminAuthenticationEndpointAdder : IEndpointAdder
{
    public void AddEndpoint(WebApplication app, ServiceCollectionSettings settings)
    {
        app.MapGet("/admin/authentication/{password}",
                (string password) =>
                {
                    SystemAdministratorLoginCommand curCommand =
                        ActivatorUtilities.CreateInstance<SystemAdministratorLoginCommand>(settings.Provider, password);

                    return curCommand.Execute() is Result.Success;
                })
            .WithDescription("Return true if password is correct, otherwise false")
            .WithOpenApi();
    }
}
