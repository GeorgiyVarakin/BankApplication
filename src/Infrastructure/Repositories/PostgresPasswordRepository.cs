using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
using Src.Application.Abstractions;
using Src.Application.Abstractions.Respository;

namespace Src.Infrastructure.Repositories;

public class PostgresPasswordRepository(IPostgresConnectionProvider connectionProvider,
    IPasswordEncryptor encryptor) : IPasswordRepository
{
    public async Task<bool> TryLoginByPassword(long id, string password)
    {
        string passwordCode = encryptor.Encrypt(password);

        string text = "select * from accountpassword where id = @id and password = @password";

        NpgsqlCommand command = new NpgsqlCommand(text, await connectionProvider.GetConnectionAsync(default))
            .AddParameter("@id", id)
            .AddParameter("@password", passwordCode);

        NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        return await reader.ReadAsync();
    }
}
