using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Src.Application.Models;
using Src.Presentation.Commands.BankAccountCommands;

namespace Src.Presentation.ConsoleUI.ConsoleUI.Pages.UserActionPages;

public class ShowAccountHistoryPage : IPage
{
    public async Task<IPage> Execute(PageState state)
    {
        if (state.Account is null)
        {
            PagesWindows.ContinueWindow("[Red]Error.[/] Account is null!");
            return state.Provider.GetRequiredService<RoleChoosePage>();
        }

        ShowAccountHistoryCommand curCommand =
            ActivatorUtilities.CreateInstance<ShowAccountHistoryCommand>(state.Provider, state.Account.AccountGuid);

        var result = await curCommand.Execute();

        var table = new Table();

        table.AddColumns("ID", "Datetime", "Balance before", "Balance after", "Delta", "Type");

        foreach (Log s in result)
        {
            string type = "Add";
            if (s.Delta < 0)
            {
                type = "Withdraw";
            }

            table.AddRow(s.AccountId.ToString(),
                         s.Datetime,
                         s.BalanceBeforeOperation.ToString(),
                         s.BalanceAfterOperation.ToString(),
                         s.Delta.ToString(),
                         type);
        }

        AnsiConsole.Write(table);

        PagesWindows.ContinueWindow();

        return state.Provider.GetRequiredService<UserPage>();
    }
}
