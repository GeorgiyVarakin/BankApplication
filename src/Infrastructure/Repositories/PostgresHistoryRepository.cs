using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
using Src.Application.Abstractions.Respository;
using Src.Application.Models;

namespace Src.Infrastructure.Repositories;

public class PostgresHistoryRepository(IPostgresConnectionProvider connectionProvider) : IHistoryRepository
{
    public async Task AddHistoryRecord(Log log)
    {
        string text = "insert into TransactionsHistory values (@id, @date, @balanceBefore, @balanceAfter, @delta)";

        NpgsqlCommand command = new NpgsqlCommand(text, await connectionProvider.GetConnectionAsync(default))
            .AddParameter("@id", log.AccountId)
            .AddParameter("@date", log.Datetime)
            .AddParameter("@balanceBefore", log.BalanceBeforeOperation)
            .AddParameter("@balanceAfter", log.BalanceAfterOperation)
            .AddParameter("@delta", log.Delta);

        await command.ExecuteNonQueryAsync();
    }

    public async Task<List<Log>> ShowHistory(long id)
    {
        string text = "select * from TransactionsHistory where id = @id";

        NpgsqlCommand command = new NpgsqlCommand(text, await connectionProvider.GetConnectionAsync(default))
            .AddParameter("@id", id);

        NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        List<Log> list = [];

        while (await reader.ReadAsync())
        {
            var newLog = new Log(
                reader.GetInt64(0),
                reader.GetString(1),
                reader.GetInt64(2),
                reader.GetInt64(3),
                reader.GetInt64(4));
            list.Add(newLog);
        }

        return list;
    }
}
