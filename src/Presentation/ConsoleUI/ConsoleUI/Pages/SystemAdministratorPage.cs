using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Src.Presentation.ConsoleUI.ConsoleUI.Pages;

public class SystemAdministratorPage : IPage
{
    public Task<IPage> Execute(PageState state)
    {
        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("This is system administrator page.")
                .AddChoices([
                    "Log out",
                ]));

        state.AdministratorLoggedOut();
        return Task.FromResult<IPage>(
            state.Provider.GetRequiredService<RoleChoosePage>());
    }
}
