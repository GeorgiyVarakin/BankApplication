using Src.Application.Abstractions.Respository;
using Src.Application.Models;

namespace Src.Presentation.Commands;

public class IdentificationNewBankAccountCommand(string password,
    IAccountRepository accountRepository) : ICommand<Task<BankAccount?>>
{
    public async Task<BankAccount?> Execute()
    {
        BankAccount? result = await accountRepository.MakeNewAccount(password);
        return result;
    }
}
