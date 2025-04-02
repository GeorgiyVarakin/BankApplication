using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Src.Presentation.ConsoleUI.ConsoleUI.Pages;

public class RoleChoosePage : IPage
{
    public Task<IPage> Execute(PageState state)
    {
        string role = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose a [green]role[/]:")
                .AddChoices([
                    "User", "System Administrator"
                ]));

        return Task.FromResult<IPage>(role == "User"
            ? state.Provider.GetRequiredService<UserActionChoosePage>()
            : state.Provider.GetRequiredService<SystemAdministratorLoginPage>());
    }
}
