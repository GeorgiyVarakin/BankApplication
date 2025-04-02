using Spectre.Console;
using Src.ApplicationLaunchers.ServiceCollection;
using Src.Presentation.ConsoleUI.ConsoleUI;
using Src.Presentation.ConsoleUI.ConsoleUI.Pages;

namespace Src.ApplicationLaunchers.Console;

public class ConsoleApplicationLauncher : IApplicationLauncher
{
    public async Task Launch(ServiceCollectionSettings settings)
    {
        PageState state = new(settings);

        var start = new RoleChoosePage();
        IPage page = await start.Execute(state);

        while (true)
        {
            page = await page.Execute(state);
            AnsiConsole.Clear();
            if (state.NeedExit)
            {
                break;
            }
        }
    }
}
