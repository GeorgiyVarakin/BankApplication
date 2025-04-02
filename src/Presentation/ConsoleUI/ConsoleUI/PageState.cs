using Src.Application.Models;
using Src.ApplicationLaunchers.ServiceCollection;

namespace Src.Presentation.ConsoleUI.ConsoleUI;

public class PageState(ServiceCollectionSettings settings)
{
    public void BankAccountLoggedIn(BankAccount acc)
    {
        Account = acc;
    }

    public void BankAccountLoggedOut()
    {
        Account = null;
    }

    public void AdministratorLoggedIn()
    {
        IsAdministrator = true;
    }

    public void AdministratorLoggedOut()
    {
        IsAdministrator = false;
    }

    public void WrongPasswordForSystemAdministrator()
    {
        NeedExit = true;
    }

    public IServiceProvider Provider { get; init; } = settings.Provider;

    public BankAccount? Account { get; private set; }

    public bool IsAdministrator { get; private set; }

    public bool NeedExit { get; private set; }
}
