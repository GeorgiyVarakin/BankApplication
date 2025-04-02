using Microsoft.Extensions.DependencyInjection;
using Src.Presentation.Commands;
using Src.Presentation.Commands.BankAccountCommands;

namespace Src.ApplicationLaunchers.ServiceCollection.Setups.Extensions;

public static class CommandExtension
{
    public static void AddCommands(this IServiceCollection collection)
    {
        collection.AddScoped<AddMoneyCommand>();
        collection.AddScoped<WithdrawMoneyCommand>();
        collection.AddScoped<ShowBalanceCommand>();
        collection.AddScoped<ShowAccountHistoryCommand>();
        collection.AddScoped<AuthenticationBankAccountCommand>();
        collection.AddScoped<IdentificationNewBankAccountCommand>();
        collection.AddScoped<SystemAdministratorLoginCommand>();
    }
}
