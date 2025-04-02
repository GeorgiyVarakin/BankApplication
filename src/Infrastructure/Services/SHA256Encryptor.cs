using Src.Application.Abstractions;
using System.Security.Cryptography;
using System.Text;

namespace Src.Infrastructure.Services;

public class SHA256Encryptor : IPasswordEncryptor
{
    public string Encrypt(string s)
    {
        var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
        return Convert.ToHexStringLower(bytes);
    }
}
