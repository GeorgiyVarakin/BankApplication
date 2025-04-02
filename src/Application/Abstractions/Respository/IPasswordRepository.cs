namespace Src.Application.Abstractions.Respository;

public interface IPasswordRepository
{
    Task<bool> TryLoginByPassword(long id, string password);
}
