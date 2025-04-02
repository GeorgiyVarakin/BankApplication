using Microsoft.Extensions.DependencyInjection;
using Src.Presentation.Commands.BankAccountCommands;

namespace Src.Presentation.ConsoleUI.ConsoleUI.Pages.UserActionPages;

public class ShowBalancePage : IPage
{
    public async Task<IPage> Execute(PageState state)
    {
        if (state.Account is null)
        {
            PagesWindows.ContinueWindow("[Red]Error.[/] Account is null!");
            return state.Provider.GetRequiredService<RoleChoosePage>();
        }

        ShowBalanceCommand curCommand =
            ActivatorUtilities.CreateInstance<ShowBalanceCommand>(state.Provider, state.Account.AccountGuid);

        long? balance = await curCommand.Execute();

        PagesWindows.ContinueWindow($"Balance is {balance}");

        return state.Provider.GetRequiredService<UserPage>();
    }
}
