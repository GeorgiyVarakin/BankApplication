using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
using Src.Application.Abstractions.Respository;

namespace Src.Infrastructure.Repositories;

public class PostgresBalanceRepository(IPostgresConnectionProvider connectionProvider) : IBalanceRepository
{
    public async Task<long?> GetBalance(long id)
    {
        string text = "select balance from accountbalance where id = @id";

        NpgsqlCommand command = new NpgsqlCommand(text, await connectionProvider.GetConnectionAsync(default))
            .AddParameter("@id", id);

        NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        return await reader.ReadAsync() is false ? null : reader.GetInt64(0);
    }

    public async Task UpdateMoney(long id, long? newBalance)
    {
        string text = "update accountbalance set balance = @newBalance where id = @id";

        NpgsqlCommand command = new NpgsqlCommand(text, await connectionProvider.GetConnectionAsync(default))
            .AddParameter("@id", id)
            .AddParameter("@newBalance", newBalance);

        await command.ExecuteNonQueryAsync();
    }
}
