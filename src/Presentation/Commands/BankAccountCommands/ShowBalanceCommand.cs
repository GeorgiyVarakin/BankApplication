using Src.Application.Abstractions;

namespace Src.Presentation.Commands.BankAccountCommands;

public class ShowBalanceCommand(long id,
    ICurrentAccountService service) : ICommand<Task<long?>>
{
    public async Task<long?> Execute()
    {
        return await service.GetBalance(id);
    }
}
