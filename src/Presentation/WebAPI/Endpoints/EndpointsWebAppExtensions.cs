using Microsoft.AspNetCore.Builder;
using Src.ApplicationLaunchers.ServiceCollection;
using Src.Presentation.WebAPI.Endpoints.AdminEndpoints;
using Src.Presentation.WebAPI.Endpoints.BankAccountEndpoints;
using Src.Presentation.WebAPI.Endpoints.BankAccountEndpoints.BankOperationsEndpoints;

namespace Src.Presentation.WebAPI.Endpoints;

public static class EndpointsWebAppExtensions
{
    public static void AddEndpoints(this WebApplication app, ServiceCollectionSettings settings)
    {
        EndpointsHandler handler = new EndpointsHandler()
            .AddEndpointAdder(new AdminAuthenticationEndpointAdder())
            .AddEndpointAdder(new NewBankAccountIdentificationEndpointAdder())
            .AddEndpointAdder(new BankAccountAuthenticationEndpointAdder())
            .AddEndpointAdder(new AddMoneyOperationEndpointAdder())
            .AddEndpointAdder(new WithdrawMoneyOperationEndpointAdder())
            .AddEndpointAdder(new ShowBalanceEndpointAdder())
            .AddEndpointAdder(new ShowAccountHistoryEndpointAdder());

        handler.AddEndpoint(app, settings);
    }
}
