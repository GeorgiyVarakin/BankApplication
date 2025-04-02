namespace Src.Infrastructure.DatabaseManager;

public interface IDatabaseManager
{
    Task DatabaseSetup();

    Task DatabaseRemove();
}
