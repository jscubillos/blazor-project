namespace Blazor.Project.Application.Interfaces;

public interface IPasswordService
{
    string GenerateSalt();
    string HashPassword(string password, string salt);
    bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt);
}