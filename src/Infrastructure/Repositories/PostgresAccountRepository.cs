using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
using Src.Application;
using Src.Application.Abstractions;
using Src.Application.Abstractions.Respository;
using Src.Application.Models;

namespace Src.Infrastructure.Repositories;

public class PostgresAccountRepository(IPostgresConnectionProvider connectionProvider, IGuidProvider guidProvider,
    IPasswordEncryptor encryptor) : IAccountRepository
{
    public async Task<BankAccount?> MakeNewAccount(string password)
    {
        if (password.Length < ApplicationConstants.MinPasswordLength ||
            password.Length > ApplicationConstants.MaxPasswordLength)
        {
            return null;
        }

        long id = await guidProvider.MakeNewGuid();

        string text = "insert into accountbalance values (@id, 0)";

        string passwordCode = encryptor.Encrypt(password);

        NpgsqlCommand command = new NpgsqlCommand(text, await connectionProvider.GetConnectionAsync(default))
            .AddParameter("@id", id);

        await command.ExecuteNonQueryAsync();

        text = "insert into accountpassword values (@id, @password)";

        command = new NpgsqlCommand(text, await connectionProvider.GetConnectionAsync(default))
            .AddParameter("@id", id)
            .AddParameter("@password", passwordCode);

        await command.ExecuteNonQueryAsync();

        return new BankAccount(id, 0);
    }

    public async Task<BankAccount?> FindAccountByNumber(long id)
    {
        string text = "select * from accountbalance where id = @id";

        NpgsqlCommand command = new NpgsqlCommand(text, await connectionProvider.GetConnectionAsync(default))
            .AddParameter("@id", id);

        NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        return await reader.ReadAsync() is false
            ? null
            : new BankAccount(reader.GetInt64(0),
            reader.GetInt64(1));
    }
}
