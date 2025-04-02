using Src.Application.Models;

namespace Src.Application.Abstractions.Respository;

public interface IAccountRepository
{
    Task<BankAccount?> MakeNewAccount(string password);

    Task<BankAccount?> FindAccountByNumber(long id);
}
