using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace Src.Infrastructure.DatabaseManager;

public class PostgresDatabaseManager(IPostgresConnectionProvider provider) : IDatabaseManager
{
    public async Task DatabaseSetup()
    {
        string text = "create table if not exists AccountBalance (Id bigint, Balance bigint);" +
                      "create table if not exists AccountPassword (Id bigint, Password varchar(64));" +
                      "create table if not exists TransactionsHistory (Id bigserial, DataTime varchar(30)," +
                      "BalanceBefore bigint, BalanceAfter bigint, Delta bigint);";

        var command = new NpgsqlCommand(text, await provider.GetConnectionAsync(default));

        await command.ExecuteNonQueryAsync();
    }

    public async Task DatabaseRemove()
    {
        string text = "drop table if exists AccountBalance;\n" +
                      "drop table if exists AccountPassword;\n" +
                      "drop table if exists TransactionsHistory;";

        var command = new NpgsqlCommand(text, await provider.GetConnectionAsync(default));

        await command.ExecuteNonQueryAsync();
    }
}
