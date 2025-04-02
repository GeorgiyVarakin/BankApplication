using Microsoft.AspNetCore.Builder;
using Src.ApplicationLaunchers.ServiceCollection;

namespace Src.Presentation.WebAPI.Endpoints;

public interface IEndpointAdder
{
    void AddEndpoint(WebApplication app, ServiceCollectionSettings settings);
}
