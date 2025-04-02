using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Src.Presentation.ConsoleUI.ConsoleUI.Pages;

public class UserActionChoosePage : IPage
{
    public Task<IPage> Execute(PageState state)
    {
        string role = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Do you want to [blue]log in[/] to your account or [blue]create[/] a new one?")
                .AddChoices([
                    "Log in", "Create", "Return"
                ]));

        IServiceProvider provider = state.Provider;

        if (role == "Return")
        {
            return Task.FromResult<IPage>(
                provider.GetRequiredService<RoleChoosePage>());
        }

        return Task.FromResult<IPage>(role == "Log in"
            ? provider.GetRequiredService<AccountLoginPage>()
            : provider.GetRequiredService<CreateAccountPage>());
    }
}
