using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Src.Application.ResultType;
using Src.Presentation.Commands;

namespace Src.Presentation.ConsoleUI.ConsoleUI.Pages;

public class SystemAdministratorLoginPage : IPage
{
    public Task<IPage> Execute(PageState state)
    {
        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Write [red]system password[/]:")
                .Secret());

        SystemAdministratorLoginCommand curCommand =
            ActivatorUtilities.CreateInstance<SystemAdministratorLoginCommand>(state.Provider, password);

        Result result = curCommand.Execute();

        if (result is Result.Fail)
        {
            state.WrongPasswordForSystemAdministrator();

            PagesWindows.ContinueWindow(result.ResultMessage);

            return Task.FromResult<IPage>(this);
        }

        state.AdministratorLoggedIn();

        string msg = "[green]Successful login[/]";
        PagesWindows.ContinueWindow(msg);

        return Task.FromResult<IPage>(
            state.Provider.GetRequiredService<SystemAdministratorPage>());
    }
}
