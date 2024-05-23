using Blazor.Project.Domain.Common;

namespace Blazor.Project.Domain.Users;

public class User : Entity
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string PasswordHash { get; set; }
    public required string PasswordSalt { get; set; }
}