using Src.Application.Models;
using Src.Application.ResultType;

namespace Src.Presentation.Commands.BankAccountCommands;

public class BankOperationAnswer(bool isSuccess, Result result, BankAccount? bankAccount = null, Log? log = null)
{
    public bool IsSuccess { get; init; } = isSuccess;

    public Result Result { get; init; } = result;

    public BankAccount? BankAccount { get; init; } = bankAccount;

    public Log? NewLog { get; init; } = log;
}
