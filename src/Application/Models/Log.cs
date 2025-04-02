namespace Src.Application.Models;

public record Log(long AccountId, string Datetime, long BalanceBeforeOperation, long BalanceAfterOperation, long Delta) { }
