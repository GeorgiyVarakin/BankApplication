using Src.Application.Models;
using Src.Application.ResultType;

namespace Src.Application.Abstractions;

public interface ICurrentAccountService
{
    Task<long?> GetBalance(long id);

    Task<Result> AddMoney(long id, long delta);

    Task<Result> WithdrawMoney(long id, long delta);

    Task<List<Log>> ShowHistory(long id);
}
