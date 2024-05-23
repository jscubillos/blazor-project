using Blazor.Project.Common.Extensions;
using Blazor.Project.Domain.Common;

namespace Blazor.Project.Domain.Users;

public class User : Dominio
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    
    public override void Validate()
    {
        ValidateName(Name);
        ValidateEmail(Email);
        ValidatePassword(Password);
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ApplicationException("Name is required");
    }
    
    private static void ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            throw new ApplicationException("Email is required");
        
        if(!email.ValidEmail())
            throw new ApplicationException("Invalid email");
    }
    
    private static void ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ApplicationException("Password is required");
    }
    
}