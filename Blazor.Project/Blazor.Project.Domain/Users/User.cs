using Blazor.Project.Domain.Interfaces;

namespace Blazor.Project.Domain.Users;

public class User : IDomain
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    
    public void Validate()
    {
        ValidateName(Name);
        ValidateEmail(Email);
        ValidatePassword(Password);
    }

    private static void ValidateName(string name)
    {
        throw new NotImplementedException();
    }
    
    private static void ValidateEmail(string email)
    {
        throw new NotImplementedException();
    }
    
    private static void ValidatePassword(string password)
    {
        throw new NotImplementedException();
    }
    
}