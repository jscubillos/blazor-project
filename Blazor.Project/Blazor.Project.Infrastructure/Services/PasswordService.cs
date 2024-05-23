using System.Security.Cryptography;
using System.Text;
using Blazor.Project.Application.Interfaces;

namespace Blazor.Project.Infrastructure.Services;

public class PasswordService : IPasswordService
{
    public string GenerateSalt()
    {
        var bytes = new byte[128 / 8];
        using var keyGenerator = RandomNumberGenerator.Create();
        keyGenerator.GetBytes(bytes);
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }

    public string HashPassword(string password, string salt)
    {
        var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password + salt));
        return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
    }

    public bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
    {
        var hashOfEnteredPassword = HashPassword(enteredPassword, storedSalt);
        return string.Equals(storedHash, hashOfEnteredPassword);
    }
}