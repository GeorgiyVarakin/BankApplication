using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Src.Presentation.ConsoleUI.ConsoleUI.Pages.UserActionPages;

namespace Src.Presentation.ConsoleUI.ConsoleUI.Pages;

public class UserPage : IPage
{
    public UserPage() { }

    public async Task<IPage> Execute(PageState state)
    {
        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"Your current account ID: [blue]{state.Account?.AccountGuid}[/]")
                .AddChoices([
                    "Add money", "Withdraw money", "Show balance", "Show history", "Log out"
                ]));

        IServiceProvider service = state.Provider;

        if (choice == "Log out")
        {
            state.BankAccountLoggedOut();
            return service.GetRequiredService<RoleChoosePage>();
        }

        IPage nextPage = choice switch
        {
            "Add money" => service.GetRequiredService<AddMoneyPage>(),
            "Withdraw money" => service.GetRequiredService<WithdrawMoneyPage>(),
            "Show balance" => service.GetRequiredService<ShowBalancePage>(),
            "Show history" => service.GetRequiredService<ShowAccountHistoryPage>(),
            _ => this,
        };

        await nextPage.Execute(state);

        return this;
    }
}
