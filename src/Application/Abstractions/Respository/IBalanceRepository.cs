namespace Src.Application.Abstractions.Respository;

public interface IBalanceRepository
{
    Task<long?> GetBalance(long id);

    public Task UpdateMoney(long id, long? newBalance);
}
