using Spectre.Console;

namespace Src.Presentation.ConsoleUI.ConsoleUI;

public static class PagesWindows
{
    public static string ContinueWindow(string message = "")
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(message)
                .AddChoices([
                    "Continue"
                ]));
    }

    public static string TryAgainOrReturnWindow(string message = "Fail operation")
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(message)
                .AddChoices([
                    "Try again", "Return"
                ]));
    }
}
