using Src.Application.Abstractions;
using Src.Application.Models;
using Src.Application.ResultType;

namespace Src.Presentation.Commands.BankAccountCommands;

public class WithdrawMoneyCommand(long id, long delta,
    ICurrentAccountService service) : ICommand<Task<BankOperationAnswer>>
{
    public async Task<BankOperationAnswer> Execute()
    {
        long? balance = await service.GetBalance(id);

        if (balance is null)
        {
            return new BankOperationAnswer(false, new Result.Fail("Error with database or account doesn't exist"));
        }

        BankAccount account = new(id, balance.Value);

        Result result = await service.WithdrawMoney(id, delta);

        if (result is Result.Fail)
        {
            return new BankOperationAnswer(false, result, account);
        }

        var newLog = new Log(
            account.AccountGuid,
            DateTime.Now.ToString(),
            balance.Value,
            account.Balance,
            -delta);

        return new BankOperationAnswer(true, result, account, newLog);
    }
}
