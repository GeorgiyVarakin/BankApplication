using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Src.ApplicationLaunchers;
using Src.ApplicationLaunchers.ServiceCollection;
using Src.Presentation.WebAPI.Endpoints;

namespace Src.Presentation.WebAPI;

public class WebApplicationLauncher : IApplicationLauncher
{
    public async Task Launch(ServiceCollectionSettings settings)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options => options.AddPolicy("MyPolicy",
                policyBuilder => policyBuilder.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod()));

        WebApplication app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.AddEndpoints(settings);

        app.UseCors("MyPolicy");
        await app.RunAsync();
    }
}
