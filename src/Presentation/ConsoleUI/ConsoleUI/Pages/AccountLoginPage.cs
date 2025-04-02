using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Src.Application.Models;
using Src.Presentation.Commands;

namespace Src.Presentation.ConsoleUI.ConsoleUI.Pages;

public class AccountLoginPage : IPage
{
    public async Task<IPage> Execute(PageState state)
    {
        long id = AnsiConsole.Prompt(
            new TextPrompt<long>("Write your [green]account number[/]:"));

        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Write [green]password[/]:")
                .Secret());

        IServiceProvider provider = state.Provider;

        AuthenticationBankAccountCommand curCommand =
            ActivatorUtilities.CreateInstance<AuthenticationBankAccountCommand>(provider, id, password);

        BankAccount? result = await curCommand.Execute();

        if (result is null)
        {
            string choice = PagesWindows.TryAgainOrReturnWindow(
                "[Red]Error[/] when logging in. " +
                "Check account [green]number[/] and [green]password[/]");
            return choice == "Try again"
                ? this
                : provider.GetRequiredService<UserActionChoosePage>();
        }

        PagesWindows.ContinueWindow("Successful log in");

        state.BankAccountLoggedIn(result);
        return provider.GetRequiredService<UserPage>();
    }
}
