using Src.Application.Abstractions.Respository;
using Src.Application.Models;

namespace Src.Presentation.Commands;

public class AuthenticationBankAccountCommand(long id, string password,
    IAccountRepository accountRepository,
    IPasswordRepository passwordRepository) : ICommand<Task<BankAccount?>>
{
    public async Task<BankAccount?> Execute()
    {
        return await passwordRepository.TryLoginByPassword(id, password)
            ? await accountRepository.FindAccountByNumber(id) : null;
    }
}
