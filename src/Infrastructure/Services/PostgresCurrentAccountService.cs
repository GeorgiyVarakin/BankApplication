using Src.Application.Abstractions;
using Src.Application.Abstractions.Respository;
using Src.Application.Models;
using Src.Application.ResultType;

namespace Src.Infrastructure.Services;

public class PostgresCurrentAccountService(
                IBalanceRepository balanceRepository,
                IHistoryRepository historyRepository) : ICurrentAccountService
{
    public async Task<long?> GetBalance(long id)
    {
        return await balanceRepository.GetBalance(id);
    }

    public async Task<Result> AddMoney(long id, long delta)
    {
        long? newBalance = await balanceRepository.GetBalance(id);
        if (delta < 0 || newBalance is null)
        {
            return new Result.Fail();
        }

        newBalance += delta;

        var newLog = new Log(
            id,
            DateTime.Now.ToString(),
            newBalance.Value - delta,
            newBalance.Value,
            delta);

        await balanceRepository.UpdateMoney(id, newBalance);
        await historyRepository.AddHistoryRecord(newLog);

        return new Result.Success();
    }

    public async Task<Result> WithdrawMoney(long id, long delta)
    {
        long? newBalance = await balanceRepository.GetBalance(id);
        if (delta < 0 || newBalance is null || newBalance < delta)
        {
            return new Result.Fail();
        }

        newBalance -= delta;

        var newLog = new Log(
            id,
            DateTime.Now.ToString(),
            newBalance.Value + delta,
            newBalance.Value,
            -delta);

        await balanceRepository.UpdateMoney(id, newBalance);
        await historyRepository.AddHistoryRecord(newLog);

        return new Result.Success();
    }

    public async Task<List<Log>> ShowHistory(long id)
    {
        return await historyRepository.ShowHistory(id);
    }
}
