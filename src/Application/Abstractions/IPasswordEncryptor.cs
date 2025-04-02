namespace Src.Application.Abstractions;

public interface IPasswordEncryptor
{
    string Encrypt(string s);
}
