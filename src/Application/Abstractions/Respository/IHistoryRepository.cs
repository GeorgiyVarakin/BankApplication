using Src.Application.Models;

namespace Src.Application.Abstractions.Respository;

public interface IHistoryRepository
{
    public Task AddHistoryRecord(Log log);

    public Task<List<Log>> ShowHistory(long id);
}
