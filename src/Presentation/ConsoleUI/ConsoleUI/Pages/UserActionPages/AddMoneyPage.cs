using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Src.Presentation.Commands.BankAccountCommands;

namespace Src.Presentation.ConsoleUI.ConsoleUI.Pages.UserActionPages;

public class AddMoneyPage : IPage
{
    public async Task<IPage> Execute(PageState state)
    {
        long delta = AnsiConsole.Prompt(
            new TextPrompt<long>("Enter the [green]amount[/]:")
                .Validate(value => value switch
                {
                    <= 0 => ValidationResult.Error("[Red]Error.[/] Amount must be [green]positive[/]"),
                    _ => ValidationResult.Success(),
                }));

        bool finalAnswer = AnsiConsole.Prompt(
            new TextPrompt<bool>("Are you sure?")
                .AddChoice(true)
                .AddChoice(false)
                .DefaultValue(true)
                .WithConverter(choice => choice ? "y" : "n"));

        IServiceProvider provider = state.Provider;

        if (!finalAnswer)
        {
            return provider.GetRequiredService<UserPage>();
        }

        if (state.Account is null)
        {
            PagesWindows.ContinueWindow("[Red]Error.[/] Account is null!");
            return provider.GetRequiredService<RoleChoosePage>();
        }

        AddMoneyCommand curCommand =
            ActivatorUtilities.CreateInstance<AddMoneyCommand>(state.Provider, state.Account.AccountGuid, delta);

        BankOperationAnswer result = await curCommand.Execute();

        if (!result.IsSuccess)
        {
            string choice = PagesWindows.TryAgainOrReturnWindow(result.Result.ResultMessage);
            return choice == "Try again"
                ? this
                : provider.GetRequiredService<UserPage>();
        }

        PagesWindows.ContinueWindow(result.Result.ResultMessage);
        return provider.GetRequiredService<UserPage>();
    }
}
