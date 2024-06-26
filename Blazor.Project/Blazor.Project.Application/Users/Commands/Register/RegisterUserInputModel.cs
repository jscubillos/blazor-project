namespace Blazor.Project.Application.Users.Commands.Register;

public class RegisterUserInputModel
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}