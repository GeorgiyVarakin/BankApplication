namespace Src.Presentation.ConsoleUI.ConsoleUI.Pages;

public interface IPage
{
    Task<IPage> Execute(PageState state);
}
