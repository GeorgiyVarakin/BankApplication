using Src.Application.Models;
using Src.Application.ResultType;

namespace Src.Presentation.Commands;

public class SystemAdministratorLoginCommand(string password) : ICommand<Result>
{
    public Result Execute()
    {
        var account = SystemAdministrator.TryLogin(password);
        return account is null
            ? new Result.Fail("System password is wrong")
            : new Result.Success();
    }
}
