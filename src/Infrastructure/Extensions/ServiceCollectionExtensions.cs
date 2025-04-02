using Itmo.Dev.Platform.Postgres.Connection;
using Microsoft.Extensions.DependencyInjection;
using Src.Application.Abstractions;
using Src.Application.Abstractions.Respository;
using Src.Infrastructure.DatabaseManager;
using Src.Infrastructure.DatabaseSettings;
using Src.Infrastructure.Repositories;
using Src.Infrastructure.Services;

namespace Src.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection)
    {
        collection.AddSingleton<IPostgresConnectionProvider>(new PostgresConnectionProvider());

        collection.AddSingleton<IDatabaseManager, PostgresDatabaseManager>();

        collection.AddScoped<IAccountRepository, PostgresAccountRepository>();
        collection.AddScoped<IBalanceRepository, PostgresBalanceRepository>();
        collection.AddScoped<IPasswordRepository, PostgresPasswordRepository>();
        collection.AddScoped<IHistoryRepository, PostgresHistoryRepository>();

        collection.AddScoped<ICurrentAccountService, PostgresCurrentAccountService>();

        return collection;
    }
}
