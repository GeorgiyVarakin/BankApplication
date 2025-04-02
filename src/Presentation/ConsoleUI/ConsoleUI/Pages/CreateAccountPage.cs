using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Src.Application;
using Src.Application.Models;
using Src.Presentation.Commands;

namespace Src.Presentation.ConsoleUI.ConsoleUI.Pages;

public class CreateAccountPage : IPage
{
    public async Task<IPage> Execute(PageState state)
    {
        string inputMessage = "Enter the [green]password[/] for the new account (length between [blue]" +
                         ApplicationConstants.MinPasswordLength + "[/] and [blue]" +
                         ApplicationConstants.MaxPasswordLength + "[/]): ";

        string password = AnsiConsole.Prompt(
            new TextPrompt<string>(inputMessage)
                .Secret());

        IServiceProvider provider = state.Provider;

        if (password.Length < ApplicationConstants.MinPasswordLength ||
            password.Length > ApplicationConstants.MaxPasswordLength)
        {
            string errorMessage = "Length must be between [blue]10[/] and [blue]64[/]";
            string choice = PagesWindows.TryAgainOrReturnWindow(errorMessage);

            return choice == "Try again"
                ? this
                : provider.GetRequiredService<UserActionChoosePage>();
        }

        string repeatPassword = AnsiConsole.Prompt(
            new TextPrompt<string>("Repeat the [green]password[/]:")
                .Secret());

        if (password != repeatPassword)
        {
            string errorMessage = "Passwords are different";
            string choice = PagesWindows.TryAgainOrReturnWindow(errorMessage);

            return choice == "Try again"
                ? this
                : provider.GetRequiredService<UserActionChoosePage>();
        }

        IdentificationNewBankAccountCommand curCommand =
            ActivatorUtilities.CreateInstance<IdentificationNewBankAccountCommand>(provider, password);
        BankAccount? result = await curCommand.Execute();

        if (result is null)
        {
            string choice = PagesWindows.TryAgainOrReturnWindow(
                "[Red]Error[/] when try make new account");
            return choice == "Try again"
                ? this
                : provider.GetRequiredService<UserActionChoosePage>();
        }

        PagesWindows.ContinueWindow($"Your new account number is {result.AccountGuid}");

        state.BankAccountLoggedIn(result);
        return provider.GetRequiredService<UserPage>();
    }
}
