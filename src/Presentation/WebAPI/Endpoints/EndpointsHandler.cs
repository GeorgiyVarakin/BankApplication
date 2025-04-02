using Microsoft.AspNetCore.Builder;
using Src.ApplicationLaunchers.ServiceCollection;

namespace Src.Presentation.WebAPI.Endpoints;

public class EndpointsHandler : IEndpointAdder
{
    public EndpointsHandler AddEndpointAdder(IEndpointAdder endpointAdder)
    {
        EndPointsAdders.Add(endpointAdder);
        return this;
    }

    public void AddEndpoint(WebApplication app, ServiceCollectionSettings settings)
    {
        foreach (var elem in EndPointsAdders)
        {
            elem.AddEndpoint(app, settings);
        }
    }

    private IList<IEndpointAdder> EndPointsAdders { get; set; } = [];
}
