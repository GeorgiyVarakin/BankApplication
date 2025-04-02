using Src.ApplicationLaunchers.ServiceCollection;

namespace Src.ApplicationLaunchers;

public interface IApplicationLauncher
{
    Task Launch(ServiceCollectionSettings settings);
}
