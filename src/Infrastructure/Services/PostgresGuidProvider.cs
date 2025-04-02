using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;
using Src.Application;
using Src.Application.Abstractions;

namespace Src.Infrastructure.Services;

public class PostgresGuidProvider(IPostgresConnectionProvider provider) : IGuidProvider
{
    public async Task<long> MakeNewGuid()
    {
        string text = "select count(*) from accountbalance";

        var command = new NpgsqlCommand(text, await provider.GetConnectionAsync(default));

        NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        return await reader.ReadAsync() ? reader.GetInt64(0) + ApplicationConstants.MinGuid
            : ApplicationConstants.MinGuid;
    }
}
