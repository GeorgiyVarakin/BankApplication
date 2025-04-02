using Spectre.Console;

namespace Src.ApplicationLaunchers;

public class ApplicationChoosePage
{
    public string Execute()
    {
        string applicationType = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose application type:")
                .AddChoices([
                    "Console", "Web Application",
                ]));

        return applicationType;
    }
}
