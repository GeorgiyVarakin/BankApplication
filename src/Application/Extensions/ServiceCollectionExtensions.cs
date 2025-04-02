using Microsoft.Extensions.DependencyInjection;
using Src.Application.Abstractions;
using Src.Infrastructure.Services;

namespace Src.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<ICurrentAccountService, PostgresCurrentAccountService>();

        collection.AddScoped<IGuidProvider, PostgresGuidProvider>();

        collection.AddScoped<IPasswordEncryptor, SHA256Encryptor>();

        return collection;
    }
}
