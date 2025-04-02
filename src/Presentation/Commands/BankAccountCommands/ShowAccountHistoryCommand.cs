using Src.Application.Abstractions;
using Src.Application.Models;

namespace Src.Presentation.Commands.BankAccountCommands;

public class ShowAccountHistoryCommand(long id,
    ICurrentAccountService service) : ICommand<Task<IList<Log>>>
{
    public async Task<IList<Log>> Execute()
    {
        return await service.ShowHistory(id);
    }
}
