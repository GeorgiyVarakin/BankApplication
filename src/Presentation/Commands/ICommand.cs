namespace Src.Presentation.Commands;

public interface ICommand<out T>
{
    T Execute();
}
