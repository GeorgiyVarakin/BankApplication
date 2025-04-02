using Microsoft.Extensions.DependencyInjection;
using Src.Presentation.ConsoleUI.ConsoleUI.Pages;
using Src.Presentation.ConsoleUI.ConsoleUI.Pages.UserActionPages;

namespace Src.ApplicationLaunchers.Console.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddConsolePages(this IServiceCollection collection)
    {
        collection.AddScoped<RoleChoosePage>();
        collection.AddScoped<SystemAdministratorLoginPage>();
        collection.AddScoped<SystemAdministratorPage>();
        collection.AddScoped<UserActionChoosePage>();
        collection.AddScoped<CreateAccountPage>();
        collection.AddScoped<AccountLoginPage>();
        collection.AddScoped<UserPage>();
        collection.AddScoped<AddMoneyPage>();
        collection.AddScoped<WithdrawMoneyPage>();
        collection.AddScoped<ShowBalancePage>();
        collection.AddScoped<ShowAccountHistoryPage>();
    }
}
